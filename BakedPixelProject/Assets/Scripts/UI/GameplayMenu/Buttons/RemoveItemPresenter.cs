using System;
using Inventories.Domain;
using Inventories.Services;
using UnityEngine;

namespace UI.GameplayMenu.Buttons
{
	public class RemoveItemPresenter : IDisposable
	{
		private readonly RemoveItemButton _removeItemButton;
		private readonly IInventoryService _inventoryService;

		public RemoveItemPresenter(RemoveItemButton removeItemButton, IInventoryService inventoryService)
		{
			_removeItemButton = removeItemButton;
			_inventoryService = inventoryService;
		}

		public void Show()
		{
			_removeItemButton.Clicked += OnClicked;
		}

		public void Dispose()
		{
			_removeItemButton.Clicked -= OnClicked;
		}

		private void OnClicked()
		{
			bool isEmptySlot = true;

			InventorySlot slot = null;

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

			slot.Clear();
		}
	}
}