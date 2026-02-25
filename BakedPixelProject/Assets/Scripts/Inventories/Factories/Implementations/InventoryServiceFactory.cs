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
using Services.SaveLoadServices;
using Services.StaticDataServices;
using Wallets.Services;
using Weapons;

namespace Inventories.Factories.Implementations
{
	public class InventoryServiceFactory : IInventoryServiceFactory, IProgressReader
	{
		private readonly IRandomService _randomService;
		private readonly IWalletService _walletService;
		private readonly ISaveLoadService _saveLoadService;
		private readonly IStaticDataService _staticDataService;
		private List<InventorySlot> _inventorySlots;

		public InventoryServiceFactory(
			IStaticDataService staticDataService,
			IRandomService randomService,
			IWalletService walletService,
			ISaveLoadService saveLoadService)
		{
			_randomService = randomService;
			_walletService = walletService;
			_saveLoadService = saveLoadService;
			_staticDataService = staticDataService;
		}

		public IInventoryService Create()
		{
			if (_saveLoadService.HasSavedProgress == false)
			{
				InventoryConfig inventoryConfig = _staticDataService.GetInventoryConfig();
				_inventorySlots = new List<InventorySlot>(inventoryConfig.Capacity);

				for (int i = 0; i < inventoryConfig.Capacity; i++)
					_inventorySlots.Add(new InventorySlot(i, i >= inventoryConfig.UnlockSlotCountOnDefault));
			}

			return new InventoryService(_inventorySlots, _staticDataService, _randomService, _walletService);
		}

		public void ReadProgress(ProjectProgress projectProgress)
		{
			List<Slot> inventorySlots = projectProgress.Inventory.Slots;
			_inventorySlots = new List<InventorySlot>(inventorySlots.Count);

			for (int i = 0; i < inventorySlots.Count; i++)
			{
				InventorySlot inventorySlot = new InventorySlot(inventorySlots[i].Id, inventorySlots[i].IsLocked);
				
				if (inventorySlot.IsLocked)
					continue;

				if (inventorySlots[i].ItemKey.Type == InventoryItemType.Empty)
				{
					inventorySlot.Set(ItemKey.CreateEmptyItem(), 0, 0f);
					continue;
				}

				float weight = GetItemWeight(inventorySlots[i]);

				inventorySlot.Set(
					new ItemKey(
						inventorySlots[i].ItemKey.Type, 
						inventorySlots[i].ItemKey.EnumItemId),
						inventorySlots[i].Amount,weight);

				_inventorySlots.Add(inventorySlot);
			}
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