using System;
using Bullets;
using Inventories;
using Inventories.Domain;
using Inventories.Services;
using UI.GameplayMenu.Inventories.Buttons.Views;
using UnityEngine;

namespace UI.GameplayMenu.Inventories.Buttons.Presenters
{
	public class AddBulletsPresenter : IDisposable
	{
		private readonly IInventoryService _inventoryService;
		private readonly AddBulletsButton _button;
		private readonly BulletType[] _bulletTypes;

		public AddBulletsPresenter(
			IInventoryService inventoryService, 
			AddBulletsButton button, 
			BulletType[] bulletTypes)
		{
			_inventoryService = inventoryService;
			_button = button;
			_bulletTypes = bulletTypes;
		}

		public void Show() =>
			_button.Clicked += OnButtonClicked;

		public void Dispose() =>
			_button.Clicked -= OnButtonClicked;

		private void OnButtonClicked(int bulletCount)
		{
			foreach (BulletType bulletType in _bulletTypes)
			{
				if (_inventoryService.TrySetStackableItem(new ItemKey(InventoryItemType.Ammo, (int)bulletType), bulletCount) == false)
					Debug.LogError($"{bulletType} could not be added");
			}
		}
	}
}