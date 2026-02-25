using Inventories.Domain;
using Inventories.Factories.Interfaces;
using Inventories.Services;
using Inventories.Spawners;
using Services.StaticDataServices;
using UI.GameplayMenu.Inventories;
using UnityEngine;

namespace Inventories.Factories.Implementations
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

		public InventorySlotPresenter Create(IReadOnlyInventorySlot inventorySlot, Transform slotsParent)
		{
			InventorySlotView inventorySlotView = _inventoryViewSpawner.Spawn(slotsParent);

			return new InventorySlotPresenter(inventorySlot, inventorySlotView, _staticDataService, _inventoryService);
		}
	}
}