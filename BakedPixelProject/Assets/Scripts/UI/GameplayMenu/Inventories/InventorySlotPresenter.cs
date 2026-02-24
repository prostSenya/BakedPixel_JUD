using System;
using Armors;
using Bullets;
using Helpers;
using Inventories;
using Inventories.Domain;
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

		public InventorySlotPresenter(
			IReadOnlyInventorySlot inventorySlot,
			InventorySlotView inventorySlotView,
			IStaticDataService staticDataService)
		{
			_inventorySlot = inventorySlot;
			_inventorySlotView = inventorySlotView;
			_staticDataService = staticDataService;
		}

		public void Show()
		{
			_inventorySlot.Updated += UpdateInventorySlotView;
			UpdateInventorySlotView();
		}

		public void Hide()
		{
			_inventorySlot.Updated -= UpdateInventorySlotView;
		}

		private void UpdateInventorySlotView()
		{
			Sprite sprite = _inventorySlot.HasItem ? GetItemSprite() : GetSlotViewSprite();

			string textCount = _inventorySlot.Count == 0 ? string.Empty : _inventorySlot.Count.ToString();

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

				case InventoryItemType.Consumables:
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