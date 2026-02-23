using Inventories.Configs;
using Inventories.Domain;
using Services.StaticDataServices;
using UI.GameplayMenu.Inventories;

namespace Inventories.Factories
{
	public class InventorySlotFactory : IInventorySlotFactory
	{
		private readonly IStaticDataService _staticDataService;

		public InventorySlotFactory(IStaticDataService staticDataService)
		{
			_staticDataService = staticDataService;
		}
		
		public InventorySlot Create(bool isLocked = false)
		{
			InventorySlotConfig inventorySlotConfig = _staticDataService.GetInventorySlotConfig();
			return new InventorySlot(isLocked, inventorySlotConfig.UnlockSlotPrice, InventoryItemType.Unknown);
		}
	}
}