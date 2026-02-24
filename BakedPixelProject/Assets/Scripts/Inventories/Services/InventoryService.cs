using System;
using System.Collections.Generic;
using System.Linq;
using Bullets;
using Helpers;
using Inventories.Domain;
using Services.RandomServices;
using Services.StaticDataServices;
using Weapons;

namespace Inventories.Services
{
	public class InventoryService : IInventoryService
	{
		private readonly List<InventorySlot> _inventorySlots;
		private readonly IStaticDataService _staticDataService;
		private readonly IRandomService _randomService;

		public InventoryService(
			List<InventorySlot> inventorySlots, 
			IStaticDataService staticDataService,
			IRandomService randomService)
		{
			_inventorySlots = inventorySlots;
			_staticDataService = staticDataService;
			_randomService = randomService;
		}

		public bool IsEmptyInventory => _inventorySlots.All(x => x.HasItem == false);
		public int SlotCount => _inventorySlots.Count;
		public IReadOnlyList<IReadOnlyInventorySlot> Slots => _inventorySlots;
		public bool IsFullInventory() =>
			_inventorySlots
			.Where(inventorySlot => inventorySlot.IsLocked == false)
			.All(inventorySlot => inventorySlot.HasItem);
		
		public bool TrySetStackableItem(ItemKey itemKey, int count)
		{
			if (count <= 0)
				return false;

			bool isStackable = false;
			int maxStackableCount = 1;
			
			if (EnumHelper.TryParse(itemKey.EnumId, out BulletType bulletType))
			{
				BulletConfig bulletConfig = _staticDataService.GetBulletConfig(bulletType);
				isStackable = bulletConfig.IsStackable;
				maxStackableCount = bulletConfig.MaxStackCount;
			};

			if (isStackable)
			{
				foreach (InventorySlot slot in _inventorySlots)
				{
					if (slot.IsLocked)
						continue;
					
					if (slot.Key.Equals(itemKey) == false)
						continue;
					
					int freeCount = maxStackableCount - slot.Count;
					
					if (freeCount <= 0)
						continue;
					
					int toAdd = Math.Min(freeCount, count);
					slot.Set(itemKey, slot.Count + toAdd);
					count -= toAdd;
					
					if (count <= 0)
						return true;
				}
			}
			
			foreach (InventorySlot slot in _inventorySlots)
			{
				if (slot.IsLocked || slot.HasItem)
					continue;

				int countToAdd = Math.Min(maxStackableCount, count);
				
				slot.Set(itemKey, countToAdd);
				count -= countToAdd;
				
				if (count <= 0)
					return true;
			}

			return false;
		}

		public bool TrySetItem(ItemKey itemKey, int count = 1)
		{
			if (count <= 0)
				return  false;
			
			foreach (InventorySlot slot in _inventorySlots)
			{
				if (slot.IsLocked || slot.HasItem)
					continue;

				slot.Set(itemKey, 1);
				count--;
				
				if (count <= 0)
					return true;
			}

			return false;

		}

		public void ClearSlot(IReadOnlyInventorySlot slot) => 
			_inventorySlots[slot.Id]?.Clear();

		public bool TryGetWeaponByBullet(BulletType bulletType, out WeaponType weaponType)
		{
			weaponType = WeaponType.Unknown;

			foreach (InventorySlot slot in _inventorySlots)
			{
				if (slot.HasItem == false)
					continue;

				if (slot.Key.Type != InventoryItemType.Weapon)
					continue;

				if (EnumHelper.TryParse(slot.Key.EnumId, out weaponType) == false)
					continue;

				WeaponConfig config = _staticDataService.GetWeaponConfig(weaponType);

				if (config.UniqueBulletType != bulletType)
					continue;

				return true;
			}

			return false;
		}

		public void RemoveBullet(BulletType bulletType)
		{
			InventorySlot bulletSlot = _inventorySlots
				.FirstOrDefault(
					inventorySlot =>
					inventorySlot.HasItem && 
					inventorySlot.Key.Type == InventoryItemType.Ammo &&
					EnumHelper.TryParse((int)bulletType, out BulletType _));

			if (bulletSlot == null)
				return;
			
			bulletSlot.RemoveCount(1);
		}

		public IReadOnlyInventorySlot GetRandomSlot() => 
			_randomService.GetRandomElement(_inventorySlots);
	}
}