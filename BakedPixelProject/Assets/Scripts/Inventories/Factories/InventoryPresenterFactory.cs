using Inventories.Domain;
using Services.StaticDataServices;
using UI.GameplayMenu.Inventories;
using UnityEngine;

namespace Inventories.Factories
{
	public class InventoryPresenterFactory : IInventoryPresenterFactory
	{
		private readonly IInventoryFactory _inventoryFactory;
		private readonly IInventorySlotPresenterFactory _inventorySlotPresenterFactory;

		public InventoryPresenterFactory(IInventoryFactory inventoryFactory, IInventorySlotPresenterFactory inventorySlotPresenterFactory)
		{
			_inventoryFactory = inventoryFactory;
			_inventorySlotPresenterFactory = inventorySlotPresenterFactory;
		}

		public InventoryPresenter Create(InventoryView inventoryView, Transform inventorySlotsContainer)
		{
			Inventory inventory = _inventoryFactory.Create();

			return new InventoryPresenter(inventory, inventoryView, _inventorySlotPresenterFactory, inventorySlotsContainer);
		}
	}
}