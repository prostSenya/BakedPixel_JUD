using System.Collections.Generic;
using Inventories.Domain;
using Inventories.Factories;
using Inventories.Services;
using UnityEngine;

namespace UI.GameplayMenu.Inventories
{
	public class InventoryPresenter
	{
		private readonly IInventoryService _inventoryService;
		private readonly InventoryView _inventoryView;
		private readonly IInventorySlotPresenterFactory _inventorySlotPresenterFactory;
		private readonly Transform _inventorySlotsContainer;

		private List<InventorySlotPresenter> _inventorySlotPresenters;

		public InventoryPresenter(
			IInventoryService inventoryService, 
			InventoryView inventoryView,
			IInventorySlotPresenterFactory inventorySlotPresenterFactory,
			Transform inventorySlotsContainer)
		{
			_inventoryService = inventoryService;
			_inventoryView = inventoryView;
			_inventorySlotPresenterFactory = inventorySlotPresenterFactory;
			_inventorySlotsContainer = inventorySlotsContainer;
		}

		public void Show()
		{
			 Inventory inventory = _inventoryService.Inventory;
			_inventorySlotPresenters = new List<InventorySlotPresenter>(inventory.InventorySlotCount);

			for (int i = 0; i < inventory.InventorySlotCount; i++)
			{
				InventorySlotPresenter inventorySlotPresenter = _inventorySlotPresenterFactory.Create(inventory.Slots[i], _inventorySlotsContainer);				
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