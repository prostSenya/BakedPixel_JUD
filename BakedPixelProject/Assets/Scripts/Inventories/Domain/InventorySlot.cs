namespace Inventories.Domain
{
	public class InventorySlot
	{
		private readonly int _unlockSlotPrice;

		public InventorySlot(bool isLocked, int unlockSlotPrice, InventoryItemType itemType = InventoryItemType.None)
		{
			_unlockSlotPrice = unlockSlotPrice;
			IsLocked = isLocked;
			ItemType = itemType;
		}

		public bool IsLocked { get; private set; }
		public InventoryItemType ItemType { get; private set; }
		
		public void SetItemType(InventoryItemType itemType) =>
			ItemType = itemType;
	}
}