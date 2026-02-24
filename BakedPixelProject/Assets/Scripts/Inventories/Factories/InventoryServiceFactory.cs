using System.Collections.Generic;
using Inventories.Configs;
using Inventories.Domain;
using Inventories.Services;
using Services.RandomServices;
using Services.StaticDataServices;

namespace Inventories.Factories
{
	public class InventoryServiceFactory : IInventoryServiceFactory
	{
		private readonly IInventorySlotFactory _inventorySlotFactory;
		private readonly IRandomService _randomService;
		private readonly IStaticDataService _staticDataService;

		public InventoryServiceFactory(
			IStaticDataService staticDataService, 
			IInventorySlotFactory inventorySlotFactory,
			IRandomService randomService)
		{
			_inventorySlotFactory = inventorySlotFactory;
			_randomService = randomService;
			_staticDataService = staticDataService;
		}
		
		public IInventoryService Create()
		{
			InventoryConfig inventoryConfig = _staticDataService.GetInventoryConfig();
			List<InventorySlot> inventorySlots = new List<InventorySlot>(inventoryConfig.Capacity);

			for (int i = 0; i < inventoryConfig.Capacity; i++) 
				inventorySlots.Add( _inventorySlotFactory.Create(i,i >= inventoryConfig.UnlockSlotCountOnDefault));
			
			return new InventoryService(inventorySlots, _staticDataService, _randomService);
		}
	}
}