using Inventories.Domain;
using Inventories.Services;
using UI.BaseUI.Implementations;
using UI.GameplayMenu.Inventories.Buttons.Presenters.Interfaces;
using UI.GameplayMenu.Inventories.Buttons.Views.Interfaces;
using UnityEngine;

namespace UI.GameplayMenu.Inventories.Buttons.Presenters.Implementations
{
	public class RemoveItemButtonPresenter : Presenter<IRemoveItemButtonView>, IRemoveItemButtonPresenter
	{
		private readonly IInventoryService _inventoryService;

		public RemoveItemButtonPresenter(IRemoveItemButtonView removeItemButton, IInventoryService inventoryService)
			: base(removeItemButton)
		{
			_inventoryService = inventoryService;
		}

		public override void Activate()
		{
			base.Activate();
			View.Clicked += OnClicked;
		}

		public override void Deactivate()
		{
			View.Clicked -= OnClicked;
			base.Deactivate();
		}

		private void OnClicked()
		{
			bool isEmptySlot = true;

			IReadOnlyInventorySlot slot = null;

			if (_inventoryService.IsEmptyInventory)
			{
				Debug.LogError("Cannot remove item: Inventory is empty.");
				return;
			}

			while (isEmptySlot)
			{
				slot = _inventoryService.GetRandomSlot();
				isEmptySlot = slot.HasItem == false;
			}

			_inventoryService.ClearSlot(slot);
		}
	}
}
