using Inventories.Domain;

namespace Inventories.Factories
{
	public class InventorySlotFactory : IInventorySlotFactory
	{
		public InventorySlot Create(int id, bool isLocked = false) => 
			new(id, isLocked);
	}
}