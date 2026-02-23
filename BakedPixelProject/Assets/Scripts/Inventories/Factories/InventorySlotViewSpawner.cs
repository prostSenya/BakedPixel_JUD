using Inventories.Configs;
using Services.StaticDataServices;
using UI.GameplayMenu.Inventories;
using UnityEngine;

namespace Inventories.Factories
{
	public class InventorySlotViewSpawner : IInventorySlotViewSpawner
	{
		private readonly IStaticDataService _staticDataService;
		private readonly IInventorySlotContainerProvider _inventorySlotContainerProvider;

		public InventorySlotViewSpawner(IStaticDataService staticDataService, IInventorySlotContainerProvider inventorySlotContainerProvider)
		{
			_staticDataService = staticDataService;
			_inventorySlotContainerProvider = inventorySlotContainerProvider;
		}

		// TODO InventorySlotView - IInventorySlotView
		public InventorySlotView Spawn(int count)
		{
			InventorySlotConfig config = _staticDataService.GetInventorySlotConfig();

			return	Object.Instantiate(config.Prefab, _inventorySlotContainerProvider.GetSlotContainer());
		}
	}
}