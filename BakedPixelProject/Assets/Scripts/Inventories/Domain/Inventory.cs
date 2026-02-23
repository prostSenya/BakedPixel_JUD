using System.Collections.Generic;

namespace Inventories.Domain
{
	public class Inventory
	{
		private readonly List<InventorySlot> _inventorySlots;

		public Inventory(List<InventorySlot> inventorySlots)
		{
			_inventorySlots = inventorySlots;
		}

		public int InventorySlotCount => _inventorySlots.Count;
	}
}