namespace Inventories.Domain
{
	public class InventorySlot
	{
		public InventorySlot(InventoryItemType itemType = InventoryItemType.None)
		{
			ItemType = itemType;
		}

		public bool IsLocked { get; private set; }
		public InventoryItemType ItemType { get; private set; }
		
		public void SetItemType(InventoryItemType itemType) =>
			ItemType = itemType;
	}
}