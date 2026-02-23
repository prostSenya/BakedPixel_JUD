using UI.GameplayMenu.Inventories;

namespace Inventories.Factories
{
	public interface IInventorySlotViewSpawner
	{
		InventorySlotView Spawn(int count);
	}
}