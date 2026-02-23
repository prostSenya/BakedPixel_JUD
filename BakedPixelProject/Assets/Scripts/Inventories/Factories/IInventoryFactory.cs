using UI.GameplayMenu.Inventories;

namespace Inventories.Factories
{
	public interface IInventoryFactory
	{
		Inventory Create();
	}
}