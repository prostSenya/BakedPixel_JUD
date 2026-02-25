using System;
using System.Collections.Generic;
using Armors;
using Bullets;
using Helpers;
using Inventories.Configs;
using Inventories.Domain;
using Inventories.Factories.Interfaces;
using Inventories.Services;
using Services.PersistentProgressServices;
using Services.RandomServices;
using Services.StaticDataServices;
using UnityEngine;
using Wallets.Services;
using Weapons;

namespace Inventories.Factories.Implementations
{
	public class InventoryServiceFactory : IInventoryServiceFactory
	{
		private const float BaseInventoryWeight = 0f;

		private readonly IRandomService _randomService;
		private readonly IWalletService _walletService;
		private readonly IPersistentProgressService _persistentProgressService;
		private readonly IStaticDataService _staticDataService;

		public InventoryServiceFactory(
			IStaticDataService staticDataService,
			IRandomService randomService,
			IWalletService walletService,
			IPersistentProgressService persistentProgressService)
		{
			_randomService = randomService;
			_walletService = walletService;
			_persistentProgressService = persistentProgressService;
			_staticDataService = staticDataService;
		}

		public IInventoryService Create()
		{
			List<InventorySlot> inventorySlots;

			float inventoryWeight;
			
			if (_persistentProgressService.ProjectProgress.Inventory == null)
			{
				InventoryConfig inventoryConfig = _staticDataService.GetInventoryConfig();
				inventorySlots = new List<InventorySlot>(inventoryConfig.Capacity);

				for (int i = 0; i < inventoryConfig.Capacity; i++)
					inventorySlots.Add(new InventorySlot(i, i >= inventoryConfig.UnlockSlotCountOnDefault));

				inventoryWeight = BaseInventoryWeight;
			}
			else
			{
				inventorySlots = ReadProgress(_persistentProgressService.ProjectProgress);
				inventoryWeight = _persistentProgressService.ProjectProgress.Inventory.Weight;
			}
			
			return new InventoryService(inventorySlots, _staticDataService, _randomService, _walletService, inventoryWeight);
		}

		private List<InventorySlot> ReadProgress(ProjectProgress projectProgress)
		{
			List<Slot> inventorySlots = projectProgress.Inventory.Slots;
			List<InventorySlot> inventorySlotsToResult = new List<InventorySlot>(inventorySlots.Count);

			for (int i = 0; i < inventorySlots.Count; i++)
			{
				InventorySlot inventorySlot = new InventorySlot(inventorySlots[i].Id, inventorySlots[i].IsLocked);

				if (IsEmptyInventorySlot(inventorySlot, inventorySlots, i) == false)
				{
					float weight = GetItemWeight(inventorySlots[i]);

					inventorySlot.Set(
						new ItemKey(
							inventorySlots[i].ItemKey.Type, 
							inventorySlots[i].ItemKey.EnumItemId),
						inventorySlots[i].Amount,weight);
				}

				inventorySlotsToResult.Add(inventorySlot);
			}

			return inventorySlotsToResult;
		}

		private bool IsEmptyInventorySlot(InventorySlot inventorySlot, List<Slot> inventorySlots, int i)
		{
			if (inventorySlot.IsLocked)
				return true;

			if (inventorySlots[i].ItemKey.Type == InventoryItemType.Empty)
			{
				inventorySlot.Set(ItemKey.CreateEmptyItem(), 0, 0f);
				return true;
			}

			return false;
		}

		private float GetItemWeight(Slot slot)
		{
			switch (slot.ItemKey.Type)
			{
				case InventoryItemType.Weapon:
					if (EnumHelper.TryParse(slot.ItemKey.EnumItemId, out WeaponType weaponType) == false)
						throw new Exception("Can't parse weapon type");

					return _staticDataService.GetWeaponConfig(weaponType).Weight;
				case InventoryItemType.Ammo:
					if (EnumHelper.TryParse(slot.ItemKey.EnumItemId, out BulletType bulletType) == false)
						throw new Exception("Can't parse bullet type");

					return _staticDataService.GetBulletConfig(bulletType).Weight;

				case InventoryItemType.Torso:
				case InventoryItemType.Head:
					if (EnumHelper.TryParse(slot.ItemKey.EnumItemId, out ArmorType armorType) == false)
						throw new Exception("Can't parse armor type");

					return _staticDataService.GetArmorConfig(armorType).Weight;

				case InventoryItemType.Unknown:
				default:
					throw new ArgumentOutOfRangeException(nameof(slot.ItemKey.Type), slot.ItemKey.Type, "Invalid InventoryItemType");
			}
		}
	}
}