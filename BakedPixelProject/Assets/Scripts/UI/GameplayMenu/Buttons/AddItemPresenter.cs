using System;
using System.Linq;
using Armors;
using Bullets;
using Inventories;
using Inventories.Domain;
using Inventories.Services;
using Services.RandomServices;
using Weapons;

namespace UI.GameplayMenu.Buttons
{
	public class AddItemPresenter : IDisposable
	{
		private readonly AddItemButton _addItemButton;
		private readonly IInventoryService _inventoryService;
		private readonly IRandomService _randomService;
		private readonly InventoryItemType[] _inventoryItemTypes;
		private readonly ArmorType[] _armorTypes;
		private readonly WeaponType[] _weaponTypes;

		public AddItemPresenter(
			AddItemButton addItemButton,
			IInventoryService inventoryService,
			IRandomService randomService, 
			InventoryItemType[] inventoryItemTypes, 
			ArmorType[] armorTypes,
			WeaponType[] weaponTypes)
		{
			_addItemButton = addItemButton;
			_inventoryService = inventoryService;
			_randomService = randomService;
			_inventoryItemTypes = inventoryItemTypes;
			_armorTypes = armorTypes;
			_weaponTypes = weaponTypes;

			
		}

		public void Show() => 
			_addItemButton.Clicked += OnAddItemButtonClicked;

		public void Dispose() => 
			_addItemButton.Clicked -= OnAddItemButtonClicked;

		private void OnAddItemButtonClicked()
		{
			InventoryItemType inventoryItemType = _randomService.GetRandomElement(_inventoryItemTypes);
			int enumId = -1;
			
			switch (inventoryItemType)
			{
				case InventoryItemType.Weapon:
					enumId = (int)_randomService.GetRandomElement(_weaponTypes);
					break;
				
				case InventoryItemType.Torso:
					enumId = (int)_randomService.GetRandomElement(_armorTypes);
					break;

				case InventoryItemType.Head:
					enumId = (int)_randomService.GetRandomElement(_armorTypes);
					break;
			}
			
			_inventoryService.TrySetItem(new InventorySlot.ItemKey(inventoryItemType, enumId),1);
		}
	}
}