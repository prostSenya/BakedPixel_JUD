using System;
using System.Collections.Generic;
using System.Linq;
using Armors;
using Bullets;
using Helpers;
using Inventories.Domain;
using Services.RandomServices;
using Services.StaticDataServices;
using UnityEngine;
using Wallets.Services;
using Weapons;

namespace Inventories.Services
{
	public class InventoryService : IInventoryService
	{
		private const float BaseInventoryWeight = -1f;
		
		private readonly List<InventorySlot> _inventorySlots;
		private readonly IStaticDataService _staticDataService;
		private readonly IRandomService _randomService;
		private readonly IWalletService _walletService;

		private float _inventoryWeight;

		public InventoryService(
			List<InventorySlot> inventorySlots,
			IStaticDataService staticDataService,
			IRandomService randomService,
			IWalletService walletService,
			float inventoryWeight = BaseInventoryWeight)
		{
			_inventorySlots = inventorySlots;
			_staticDataService = staticDataService;
			_randomService = randomService;
			_walletService = walletService;
			_inventoryWeight = inventoryWeight;
		}

		public event Action<float> InventaryWeightChanged;

		public float InventoryWeight
		{
			get { return _inventoryWeight; }
			private set
			{
				if (Mathf.Approximately(_inventoryWeight, value))
					return;

				if (_inventoryWeight <= BaseInventoryWeight)
				{
					_inventoryWeight = _inventorySlots
						.Where(inventorySlot => inventorySlot.IsLocked == false)
						.Sum(inventorySlot => inventorySlot.Weight);
				}
				else
				{
					_inventoryWeight = value;
				}

				InventaryWeightChanged?.Invoke(_inventoryWeight);
			}
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

			bool isStackable;
			int maxStackableCount;
			float weight;

			if (EnumHelper.TryParse(itemKey.EnumItemId, out BulletType bulletType) == false)
				throw new Exception("Invalid item key enum id: " + itemKey.EnumItemId);

			BulletConfig bulletConfig = _staticDataService.GetBulletConfig(bulletType);
			isStackable = bulletConfig.IsStackable;
			maxStackableCount = bulletConfig.MaxStackCount;
			weight = bulletConfig.Weight;

			if (isStackable)
			{
				foreach (InventorySlot slot in _inventorySlots)
				{
					if (slot.IsLocked)
						continue;

					if (slot.Key.Equals(itemKey) == false)
						continue;

					int freeCount = maxStackableCount - slot.Amount;

					if (freeCount <= 0)
						continue;

					int toAdd = Math.Min(freeCount, count);
					slot.Set(itemKey, slot.Amount + toAdd, weight);
					count -= toAdd;

					InventoryWeight += weight;

					if (count <= 0)
						return true;
				}
			}

			foreach (InventorySlot slot in _inventorySlots)
			{
				if (slot.IsLocked || slot.HasItem)
					continue;

				int countToAdd = Math.Min(maxStackableCount, count);

				slot.Set(itemKey, countToAdd, weight);
				count -= countToAdd;

				InventoryWeight += weight;

				if (count <= 0)
					return true;
			}

			return false;
		}

		public bool TrySetItem(ItemKey itemKey, int count = 1)
		{
			if (count <= 0)
				return false;

			if (itemKey.Type == InventoryItemType.Unknown)
				return false;

			float weight;

			if (itemKey.Type == InventoryItemType.Torso || itemKey.Type == InventoryItemType.Head)
			{
				ArmorConfig armorConfig = _staticDataService.GetArmorConfig((ArmorType)itemKey.EnumItemId);
				weight = armorConfig.Weight;
			}
			else if (itemKey.Type == InventoryItemType.Weapon)
			{
				WeaponConfig weaponConfig = _staticDataService.GetWeaponConfig((WeaponType)itemKey.EnumItemId);
				weight = weaponConfig.Weight;
			}
			else
			{
				throw new Exception("Invalid item key enum id: " + itemKey.EnumItemId);
			}

			foreach (InventorySlot slot in _inventorySlots)
			{
				if (slot.IsLocked || slot.HasItem)
					continue;

				slot.Set(itemKey, 1, weight);
				count--;

				InventoryWeight += weight;

				if (count <= 0)
					return true;
			}

			return false;
		}

		public void ClearSlot(IReadOnlyInventorySlot slot)
		{
			InventorySlot inventorySlot = _inventorySlots[slot.Id] ??
			                              throw new NullReferenceException($"InventorySlot {slot} not found");

			InventoryWeight -= inventorySlot.Weight;
			inventorySlot.Clear();
		}

		public bool TryUnlockSlot(IReadOnlyInventorySlot slot)
		{
			InventorySlot inventorySlot = _inventorySlots[slot.Id];

			if (inventorySlot == null)
				return false;

			if (inventorySlot.IsLocked == false)
				return false;

			int unlockSlotPrice = _staticDataService.GetInventorySlotConfig().UnlockSlotPrice;

			if (unlockSlotPrice > _walletService.Money)
				return false;

			inventorySlot.Unlock();
			_walletService.DecreaseMoney(unlockSlotPrice);

			return true;
		}

		public bool TryGetWeaponByBullet(BulletType bulletType, out WeaponType weaponType)
		{
			weaponType = WeaponType.Unknown;

			foreach (InventorySlot slot in _inventorySlots)
			{
				if (slot.HasItem == false)
					continue;

				if (slot.Key.Type != InventoryItemType.Weapon)
					continue;

				if (EnumHelper.TryParse(slot.Key.EnumItemId, out weaponType) == false)
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
				.FirstOrDefault(inventorySlot =>
					inventorySlot.HasItem &&
					inventorySlot.Key.Type == InventoryItemType.Ammo &&
					EnumHelper.TryParse((int)bulletType, out BulletType _));

			if (bulletSlot == null)
				return;

			float inventoryWeight = _staticDataService.GetBulletConfig(bulletType).Weight;

			InventoryWeight -= inventoryWeight;
			bulletSlot.RemoveCount(1);
		}

		public IReadOnlyInventorySlot GetRandomSlot() =>
			_randomService.GetRandomElement(_inventorySlots);
	}
}