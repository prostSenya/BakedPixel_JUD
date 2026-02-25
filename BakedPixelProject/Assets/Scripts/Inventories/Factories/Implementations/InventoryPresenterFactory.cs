using Inventories.Factories.Interfaces;
using Inventories.Services;
using UI.GameplayMenu.Inventories;
using UnityEngine;

namespace Inventories.Factories.Implementations
{
	public class InventoryPresenterFactory : IInventoryPresenterFactory
	{
		private readonly IInventoryService _inventoryService;
		private readonly IInventorySlotPresenterFactory _inventorySlotPresenterFactory;

		public InventoryPresenterFactory(IInventoryService inventoryService, IInventorySlotPresenterFactory inventorySlotPresenterFactory)
		{
			_inventoryService = inventoryService;
			_inventorySlotPresenterFactory = inventorySlotPresenterFactory;
		}

		public InventoryPresenter Create(InventoryView inventoryView, Transform inventorySlotsContainer) => 
			new InventoryPresenter(_inventoryService, inventoryView, _inventorySlotPresenterFactory, inventorySlotsContainer);
	}
}