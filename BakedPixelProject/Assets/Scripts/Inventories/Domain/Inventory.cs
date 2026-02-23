using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;

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
		public List<InventorySlot> Slots => _inventorySlots.ToList();
	}
}