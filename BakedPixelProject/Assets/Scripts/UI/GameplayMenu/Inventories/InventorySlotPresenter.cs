using System;
using Armors;
using Bullets;
using Helpers;
using Inventories;
using Inventories.Domain;
using Inventories.Services;
using Services.StaticDataServices;
using UnityEngine;
using Weapons;

namespace UI.GameplayMenu.Inventories
{
	public class InventorySlotPresenter
	{
		private readonly IReadOnlyInventorySlot _inventorySlot;
		private readonly InventorySlotView _inventorySlotView;
		private readonly IStaticDataService _staticDataService;
		private readonly IInventoryService _inventoryService;

		public InventorySlotPresenter(
			IReadOnlyInventorySlot inventorySlot,
			InventorySlotView inventorySlotView,
			IStaticDataService staticDataService,
			IInventoryService inventoryService)
		{
			_inventorySlot = inventorySlot;
			_inventorySlotView = inventorySlotView;
			_staticDataService = staticDataService;
			_inventoryService = inventoryService;
		}

		public void Show()
		{
			_inventorySlot.ItemSetted += UpdateInventorySlotView;
			_inventorySlot.ItemRemoved += UpdateInventorySlotView;
			_inventorySlot.Cleared += UpdateEmptyInventorySlotView;
			_inventorySlotView.Clicked += ClickedOnView;
			UpdateInventorySlotView();
		}

		public void Hide()
		{
			_inventorySlot.ItemSetted -= UpdateInventorySlotView;
			_inventorySlot.ItemRemoved -= UpdateInventorySlotView;
			_inventorySlot.Cleared -= UpdateEmptyInventorySlotView;
			_inventorySlotView.Clicked -= ClickedOnView;
		}

		private void UpdateEmptyInventorySlotView()
		{
			_inventorySlotView.SetImage(_staticDataService.GetInventorySlotConfig().SpriteOnEmptySlot);
			_inventorySlotView.SetTextCount(string.Empty);
		}

		private void ClickedOnView()
		{
			if (_inventorySlot.IsLocked == false)
				return;

			if (_inventoryService.TryUnlockSlot(_inventorySlot) == false)
			{
				Debug.LogError($"Failed to unlock inventory slot {_inventorySlot.Key}. Not enough resources.");
				return;
			}

			_inventorySlotView.SetImage(_staticDataService.GetInventorySlotConfig().SpriteOnEmptySlot);
		}

		private void UpdateInventorySlotView()
		{
			Sprite sprite = _inventorySlot.HasItem ? GetItemSprite() : GetSlotViewSprite();

			string textCount = _inventorySlot.Count <= 1 ? string.Empty : _inventorySlot.Count.ToString();

			_inventorySlotView.SetTextCount(textCount);
			_inventorySlotView.SetImage(sprite);
		}

		private Sprite GetItemSprite()
		{
			switch (_inventorySlot.Key.Type)
			{
				case InventoryItemType.Weapon:
					if (EnumHelper.TryParse(_inventorySlot.Key.EnumId, out WeaponType weaponType) == false)
						throw new Exception("Failed to parse weapon type from inventory slot ID.");
					return _staticDataService.GetWeaponConfig(weaponType).InventoryItemData.Sprite;

				case InventoryItemType.Torso:
					if (EnumHelper.TryParse(_inventorySlot.Key.EnumId, out ArmorType armorType) == false)
						throw new Exception("Failed to parse armor type from inventory slot ID.");
					return _staticDataService.GetArmorConfig(armorType).InventoryItemData.Sprite;

				case InventoryItemType.Head:
					if (EnumHelper.TryParse(_inventorySlot.Key.EnumId, out armorType) == false)
						throw new Exception("Failed to parse armor type from inventory slot ID.");
					return _staticDataService.GetArmorConfig(armorType).InventoryItemData.Sprite;

				case InventoryItemType.Ammo:
					if (EnumHelper.TryParse(_inventorySlot.Key.EnumId, out BulletType bulletType) == false)
						throw new Exception("Failed to parse bullet type from inventory slot ID.");
					return _staticDataService.GetBulletConfig(bulletType).InventoryItemData.Sprite;

				case InventoryItemType.None:
				case InventoryItemType.Unknown:
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private Sprite GetSlotViewSprite()
		{
			return _inventorySlot.IsLocked
				? _staticDataService.GetInventorySlotConfig().SpriteOnLock
				: _staticDataService.GetInventorySlotConfig().SpriteOnEmptySlot;
		}
	}
}