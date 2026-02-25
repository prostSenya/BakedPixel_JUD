using Inventories.Configs;
using Services.StaticDataServices;
using UI.GameplayMenu.Inventories;
using UnityEngine;

namespace Inventories.Spawners
{
	public class InventorySlotViewSpawner : IInventorySlotViewSpawner
	{
		private readonly IStaticDataService _staticDataService;

		public InventorySlotViewSpawner(IStaticDataService staticDataService) => 
			_staticDataService = staticDataService;

		// TODO InventorySlotView - IInventorySlotView
		public InventorySlotView Spawn(Transform parent)
		{
			InventorySlotConfig config = _staticDataService.GetInventorySlotConfig();

			return	Object.Instantiate(config.Prefab, parent);
		}
	}
}