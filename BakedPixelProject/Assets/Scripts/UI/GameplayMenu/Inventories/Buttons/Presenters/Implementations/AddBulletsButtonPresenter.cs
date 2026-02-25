using Bullets;
using Inventories;
using Inventories.Domain;
using Inventories.Services;
using UI.BaseUI.Implementations;
using UI.GameplayMenu.Inventories.Buttons.Presenters.Interfaces;
using UI.GameplayMenu.Inventories.Buttons.Views.Interfaces;
using UnityEngine;

namespace UI.GameplayMenu.Inventories.Buttons.Presenters.Implementations
{
	public class AddBulletsButtonPresenter : Presenter<IAddBulletsButtonView>, IAddBulletsButtonPresenter
	{
		private readonly IInventoryService _inventoryService;
		private readonly BulletType[] _bulletTypes;

		public AddBulletsButtonPresenter(
			IInventoryService inventoryService,
			IAddBulletsButtonView button,
			BulletType[] bulletTypes)
			: base(button)
		{
			_inventoryService = inventoryService;
			_bulletTypes = bulletTypes;
		}

		public override void Activate()
		{
			base.Activate();
			View.Clicked += OnButtonClicked;
		}

		public override void Deactivate()
		{
			View.Clicked -= OnButtonClicked;
			base.Deactivate();
		}

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
