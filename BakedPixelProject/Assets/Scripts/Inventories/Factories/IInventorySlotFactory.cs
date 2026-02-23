using Inventories.Domain;
using UI.GameplayMenu.Inventories;

namespace Inventories.Factories
{
	public interface IInventorySlotFactory
	{
		public InventorySlot Create(bool isLocked = false);
	}
}