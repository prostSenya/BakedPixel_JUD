using System;
using Inventories.Configs;
using Services.StaticDataServices;
using UI.GameplayMenu.Inventories;

namespace Inventories.Factories
{
	public class InventoryFactory : IInventoryFactory
	{
		private readonly IStaticDataService _staticDataService;

		public InventoryFactory(IStaticDataService staticDataService)
		{
			_staticDataService = staticDataService;
		}
		
		public Inventory Create()
		{
			InventoryConfig inventoryConfig = _staticDataService.GetInventoryConfig();

			if (inventoryConfig == null)
				throw new Exception("дурак");
			
			return new Inventory(
				inventoryConfig.Capacity, 
				inventoryConfig.UnlockSlotCountOnDefault, 
				inventoryConfig.UnlockSlotPrice);
		}
	}
}