using System.Collections.Generic;
using Inventories.Configs;
using Inventories.Domain;
using Services.StaticDataServices;

namespace Inventories.Factories
{
	public class InventoryFactory : IInventoryFactory
	{
		private readonly IInventorySlotFactory _inventorySlotFactory;
		private readonly IStaticDataService _staticDataService;

		public InventoryFactory(IStaticDataService staticDataService, IInventorySlotFactory inventorySlotFactory)
		{
			_inventorySlotFactory = inventorySlotFactory;
			_staticDataService = staticDataService;
		}
		
		public Inventory Create()
		{
			InventoryConfig inventoryConfig = _staticDataService.GetInventoryConfig();
			List<InventorySlot> inventorySlots = new List<InventorySlot>(inventoryConfig.Capacity);

			for (int i = 0; i < inventoryConfig.Capacity; i++) 
				inventorySlots.Add( _inventorySlotFactory.Create(i >= inventoryConfig.UnlockSlotCountOnDefault));
			
			return new Inventory(inventorySlots);
		}
	}
}