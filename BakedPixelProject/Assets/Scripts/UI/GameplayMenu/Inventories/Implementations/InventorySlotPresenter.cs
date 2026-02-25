using System;
using Armors;
using Bullets;
using Helpers;
using Inventories;
using Inventories.Domain;
using Inventories.Services;
using Services.StaticDataServices;
using UI.BaseUI.Implementations;
using UI.GameplayMenu.Inventories.Interfaces;
using UnityEngine;
using Weapons;

namespace UI.GameplayMenu.Inventories.Implementations
{
	public class InventorySlotPresenter : Presenter<IInventorySlotView>, IInventorySlotPresenter
	{
		private readonly IReadOnlyInventorySlot _inventorySlot;
		private readonly IStaticDataService _staticDataService;
		private readonly IInventoryService _inventoryService;

		public InventorySlotPresenter(
			IReadOnlyInventorySlot inventorySlot,
			IInventorySlotView inventorySlotView,
			IStaticDataService staticDataService,
			IInventoryService inventoryService)
			: base(inventorySlotView)
		{
			_inventorySlot = inventorySlot;
			_staticDataService = staticDataService;
			_inventoryService = inventoryService;
		}

		public override void Activate()
		{
			base.Activate();
			_inventorySlot.ItemSetted += UpdateInventorySlotView;
			_inventorySlot.ItemRemoved += UpdateInventorySlotView;
			_inventorySlot.Cleared += UpdateEmptyInventorySlotView;
			View.Clicked += ClickedOnView;
			UpdateInventorySlotView();
		}

		public override void Deactivate()
		{
			_inventorySlot.ItemSetted -= UpdateInventorySlotView;
			_inventorySlot.ItemRemoved -= UpdateInventorySlotView;
			_inventorySlot.Cleared -= UpdateEmptyInventorySlotView;
			View.Clicked -= ClickedOnView;
			base.Deactivate();
		}

		private void UpdateEmptyInventorySlotView()
		{
			View.SetImage(_staticDataService.GetInventorySlotConfig().SpriteOnEmptySlot);
			View.SetTextCount(string.Empty);
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

			View.SetImage(_staticDataService.GetInventorySlotConfig().SpriteOnEmptySlot);
		}

		private void UpdateInventorySlotView()
		{
			Sprite sprite = _inventorySlot.HasItem ? GetItemSprite() : GetSlotViewSprite();

			string textCount = _inventorySlot.Amount <= 1 ? string.Empty : _inventorySlot.Amount.ToString();

			View.SetTextCount(textCount);
			View.SetImage(sprite);
		}

		private Sprite GetItemSprite()
		{
			switch (_inventorySlot.Key.Type)
			{
				case InventoryItemType.Weapon:
					if (EnumHelper.TryParse(_inventorySlot.Key.EnumItemId, out WeaponType weaponType) == false)
						throw new Exception("Failed to parse weapon type from inventory slot ID.");
					return _staticDataService.GetWeaponConfig(weaponType).InventoryItemData.Sprite;

				case InventoryItemType.Torso:
					if (EnumHelper.TryParse(_inventorySlot.Key.EnumItemId, out ArmorType armorType) == false)
						throw new Exception("Failed to parse armor type from inventory slot ID.");
					return _staticDataService.GetArmorConfig(armorType).InventoryItemData.Sprite;

				case InventoryItemType.Head:
					if (EnumHelper.TryParse(_inventorySlot.Key.EnumItemId, out armorType) == false)
						throw new Exception("Failed to parse armor type from inventory slot ID.");
					return _staticDataService.GetArmorConfig(armorType).InventoryItemData.Sprite;

				case InventoryItemType.Ammo:
					if (EnumHelper.TryParse(_inventorySlot.Key.EnumItemId, out BulletType bulletType) == false)
						throw new Exception("Failed to parse bullet type from inventory slot ID.");
					return _staticDataService.GetBulletConfig(bulletType).InventoryItemData.Sprite;

				case InventoryItemType.Empty:
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
