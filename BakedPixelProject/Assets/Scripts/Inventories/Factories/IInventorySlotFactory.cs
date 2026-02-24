using Inventories.Domain;

namespace Inventories.Factories
{
	public interface IInventorySlotFactory
	{
		public InventorySlot Create(int id, bool isLocked = false);
	}
}