using System;
using System.Collections.Generic;
using Armors;
using Inventories;
using Inventories.Domain;
using Inventories.Services;
using Services.RandomServices;
using Services.StaticDataServices;
using UI.BaseUI.Implementations;
using UI.GameplayMenu.Inventories.Buttons.Presenters.Interfaces;
using UI.GameplayMenu.Inventories.Buttons.Views.Interfaces;
using UnityEngine;
using Weapons;

namespace UI.GameplayMenu.Inventories.Buttons.Presenters.Implementations
{
	public class AddItemButtonPresenter : Presenter<IAddItemButtonView>, IAddItemButtonPresenter
	{
		private readonly IInventoryService _inventoryService;
		private readonly IRandomService _randomService;
		private readonly IStaticDataService _staticDataService;
		private readonly InventoryItemType[] _inventoryItemTypes;
		private readonly WeaponType[] _weaponTypes;

		public AddItemButtonPresenter(
			IAddItemButtonView addItemButton,
			IInventoryService inventoryService,
			IRandomService randomService,
			IStaticDataService staticDataService,
			InventoryItemType[] inventoryItemTypes,
			WeaponType[] weaponTypes)
			: base(addItemButton)
		{
			_inventoryService = inventoryService;
			_randomService = randomService;
			_staticDataService = staticDataService;
			_inventoryItemTypes = inventoryItemTypes;
			_weaponTypes = weaponTypes;
		}

		public override void Activate()
		{
			base.Activate();
			View.Clicked += OnAddItemButtonClicked;
		}

		public override void Deactivate()
		{
			View.Clicked -= OnAddItemButtonClicked;
			base.Deactivate();
		}

		private void OnAddItemButtonClicked()
		{
			if (_inventoryService.IsFullInventory())
			{
				Debug.LogError("Cannot add item: Inventory is full.");
				return;
			}

			InventoryItemType inventoryItemType = _randomService.GetRandomElement(_inventoryItemTypes);
			int enumId;

			switch (inventoryItemType)
			{
				case InventoryItemType.Weapon:
					enumId = (int)_randomService.GetRandomElement(_weaponTypes);
					break;

				case InventoryItemType.Torso:
					List<ArmorConfig> armorTorsoConfigs = _staticDataService.GetTorsoArmorConfigs();
					enumId = (int)_randomService.GetRandomElement(armorTorsoConfigs).ArmorType;
					break;

				case InventoryItemType.Head:
					List<ArmorConfig> armorHeadConfigs = _staticDataService.GetHeadArmorConfigs();
					enumId = (int)_randomService.GetRandomElement(armorHeadConfigs).ArmorType;
					break;

				default:
					throw new ArgumentOutOfRangeException($"Invalid InventoryItemType: {inventoryItemType}");
			}

			if (_inventoryService.TrySetItem(new ItemKey(inventoryItemType, enumId), 1) == false)
				Debug.LogError("Cannot add item: Failed to set item.");
		}
	}
}
