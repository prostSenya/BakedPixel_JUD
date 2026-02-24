using Inventories.Domain;
using Services.StaticDataServices;
using UI.GameplayMenu.Inventories;
using UnityEngine;

namespace Inventories.Factories
{
	public class InventorySlotPresenterFactory : IInventorySlotPresenterFactory
	{
		private readonly IInventorySlotViewSpawner _inventoryViewSpawner;
		private readonly IStaticDataService _staticDataService;

		public InventorySlotPresenterFactory(
			IInventorySlotViewSpawner inventoryViewSpawner, 
			IStaticDataService staticDataService)
		{
			_inventoryViewSpawner = inventoryViewSpawner;
			_staticDataService = staticDataService;
		}

		public InventorySlotPresenter Create(IReadOnlyInventorySlot inventorySlot, Transform slotsParent)
		{
			InventorySlotView inventorySlotView = _inventoryViewSpawner.Spawn(slotsParent);

			return new InventorySlotPresenter(inventorySlot, inventorySlotView, _staticDataService);
		}
	}
}