using System.Collections.Generic;
using Inventories.Factories.Interfaces;
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
			_inventorySlotPresenters = new List<InventorySlotPresenter>(_inventoryService.SlotCount);

			for (int i = 0; i < _inventoryService.SlotCount; i++)
			{
				InventorySlotPresenter inventorySlotPresenter = _inventorySlotPresenterFactory.Create(
					_inventoryService.Slots[i], 
					_inventorySlotsContainer);				
				
				inventorySlotPresenter.Show();
				_inventorySlotPresenters.Add(inventorySlotPresenter);
			}
		}
		
		public void Hide()
		{
			foreach (InventorySlotPresenter inventorySlotPresenter in _inventorySlotPresenters) 
			 	inventorySlotPresenter.Hide();
		}
	}
}