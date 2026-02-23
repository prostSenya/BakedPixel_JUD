using Inventories.Configs;

namespace Services.StaticDataServices
{
	public interface IStaticDataService
	{
		InventoryConfig GetInventoryConfig();
		void LoadAll();
		InventorySlotConfig GetInventorySlotConfig();
	}
}