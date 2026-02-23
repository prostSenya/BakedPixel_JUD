using System.Collections.Generic;
using Inventories.Domain;
using Inventories.Factories;
using UnityEngine;

namespace UI.GameplayMenu.Inventories
{
	public class InventoryPresenter
	{
		private readonly Inventory _inventory;
		private readonly InventoryView _inventoryView;
		private readonly IInventorySlotPresenterFactory _inventorySlotPresenterFactory;
		private readonly Transform _inventorySlotsContainer;

		private List<InventorySlotPresenter> _inventorySlotPresenters;

		public InventoryPresenter(
			Inventory inventory, 
			InventoryView inventoryView,
			IInventorySlotPresenterFactory inventorySlotPresenterFactory,
			Transform inventorySlotsContainer)
		{
			_inventory = inventory;
			_inventoryView = inventoryView;
			_inventorySlotPresenterFactory = inventorySlotPresenterFactory;
			_inventorySlotsContainer = inventorySlotsContainer;
		}

		public void Show()
		{
			_inventorySlotPresenters = new List<InventorySlotPresenter>(_inventory.InventorySlotCount);

			for (int i = 0; i < _inventory.InventorySlotCount; i++)
			{
				InventorySlotPresenter inventorySlotPresenter = _inventorySlotPresenterFactory.Create(_inventory.Slots[i], _inventorySlotsContainer);				
				inventorySlotPresenter.Show();
				_inventorySlotPresenters.Add(inventorySlotPresenter);
			}
			
			//_inventoryView.Show();
		}
		
		public void Hide()
		{
			foreach (InventorySlotPresenter inventorySlotPresenter in _inventorySlotPresenters) 
				inventorySlotPresenter.Hide();

			//_inventoryView.Hide();
		}
	}
}