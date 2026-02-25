using Inventories.Domain;
using Inventories.Services;
using Inventories.Spawners;
using Services.StaticDataServices;
using UI.GameplayMenu.Factories.Interfaces;
using UI.GameplayMenu.Inventories;
using UI.GameplayMenu.Inventories.Implementations;
using UI.GameplayMenu.Inventories.Interfaces;
using UnityEngine;

namespace UI.GameplayMenu.Factories.Implementations
{
	public class InventorySlotPresenterFactory : IInventorySlotPresenterFactory
	{
		private readonly IInventorySlotViewSpawner _inventoryViewSpawner;
		private readonly IStaticDataService _staticDataService;
		private readonly IInventoryService _inventoryService;

		public InventorySlotPresenterFactory(
			IInventorySlotViewSpawner inventoryViewSpawner,
			IStaticDataService staticDataService,
			IInventoryService inventoryService)
		{
			_inventoryViewSpawner = inventoryViewSpawner;
			_staticDataService = staticDataService;
			_inventoryService = inventoryService;
		}

		public IInventorySlotPresenter Create(IReadOnlyInventorySlot inventorySlot, Transform slotsParent)
		{
			IInventorySlotView inventorySlotView = _inventoryViewSpawner.Spawn(slotsParent);

			return new InventorySlotPresenter(inventorySlot, inventorySlotView, _staticDataService, _inventoryService);
		}
	}
}
