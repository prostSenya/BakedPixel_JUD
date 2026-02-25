using System.Collections.Generic;
using Inventories.Configs;
using Inventories.Domain;
using Inventories.Factories.Interfaces;
using Inventories.Services;
using Services.RandomServices;
using Services.StaticDataServices;
using Wallets.Services;

namespace Inventories.Factories.Implementations
{
	public class InventoryServiceFactory : IInventoryServiceFactory
	{
		private readonly IRandomService _randomService;
		private readonly IWalletService _walletService;
		private readonly IStaticDataService _staticDataService;

		public InventoryServiceFactory(
			IStaticDataService staticDataService, 
			IRandomService randomService,
			IWalletService walletService)
		{
			_randomService = randomService;
			_walletService = walletService;
			_staticDataService = staticDataService;
		}
		
		public IInventoryService Create()
		{
			InventoryConfig inventoryConfig = _staticDataService.GetInventoryConfig();
			List<InventorySlot> inventorySlots = new List<InventorySlot>(inventoryConfig.Capacity);

			for (int i = 0; i < inventoryConfig.Capacity; i++) 
				inventorySlots.Add(new InventorySlot(i,i >= inventoryConfig.UnlockSlotCountOnDefault));
			
			return new InventoryService(inventorySlots, _staticDataService, _randomService, _walletService);
		}
	}
}