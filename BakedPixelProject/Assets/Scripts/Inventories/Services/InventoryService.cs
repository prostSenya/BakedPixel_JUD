using System;
using System.Collections.Generic;
using System.Linq;
using Armors;
using Bullets;
using Helpers;
using Inventories.Domain;
using Services.StaticDataServices;
using Unity.VisualScripting;
using Weapons;

namespace Inventories.Services
{
	public class InventoryService : IInventoryService
	{
		private readonly IStaticDataService _staticDataService;

		public InventoryService(Inventory inventory, IStaticDataService staticDataService)
		{
			_staticDataService = staticDataService;
			Inventory = inventory;
		}

		public Inventory Inventory { get; }

		public bool TryUnlockSlot(int slotIndex)
		{
			throw new System.NotImplementedException();
		}

		public bool TrySetItem(InventorySlot.ItemKey itemKey, int count)
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
				foreach (InventorySlot slot in Inventory.Slots)
				{
					if (slot.IsLocked)
						continue;
					
					if (slot.Key.Equals(itemKey) == false)
						continue;
					
					int freeCount = maxStackableCount - slot.Count;
					
					if (freeCount <= 0)
						continue;
						
					int stackableCount = Math.Min(count, freeCount);
					slot.Set(itemKey, stackableCount);

					count -= stackableCount;

					if (count <= 0)
						return true;
				}
			}
			
			foreach (InventorySlot slot in Inventory.Slots)
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
		
		public bool TryClearItem(int slotIndex)
		{
			throw new System.NotImplementedException();
		}

		public bool HaveWeaponTypes(IEnumerable<WeaponType> weaponTypes)
		{
			throw new System.NotImplementedException();
		}

		public bool TryGetWeaponByBullet(BulletType bulletType, out WeaponType weaponType)
		{
			weaponType = default;

			foreach (InventorySlot slot in Inventory.Slots)
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
			InventorySlot bulletSlot = Inventory.Slots
				.FirstOrDefault(s =>
					s.HasItem &&
					s.Key.Type == InventoryItemType.Consumables &&
					EnumHelper.TryParse((int)bulletType, out BulletType _));

			if (bulletSlot == null)
				return;
			
			bulletSlot.RemoveCount(1);
		}
	}
}