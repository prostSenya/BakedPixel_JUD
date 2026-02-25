using Inventories.Configs;
using Services.StaticDataServices;
using UI.GameplayMenu.Inventories;
using UI.GameplayMenu.Inventories.Interfaces;
using UnityEngine;

namespace Inventories.Spawners
{
	public class InventorySlotViewSpawner : IInventorySlotViewSpawner
	{
		private readonly IStaticDataService _staticDataService;

		public InventorySlotViewSpawner(IStaticDataService staticDataService) => 
			_staticDataService = staticDataService;

		public IInventorySlotView Spawn(Transform parent)
		{
			InventorySlotConfig config = _staticDataService.GetInventorySlotConfig();

			return	Object.Instantiate(config.Prefab, parent);
		}
	}
}
