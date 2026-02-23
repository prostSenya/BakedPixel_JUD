namespace UI.GameplayMenu.Inventories
{
	public class Inventory
	{
		public Inventory(int capacity, int unlockSlotPrice, int unlockSlotCountOnDefault)
		{
			Capacity = capacity;
			UnlockSlotPrice = unlockSlotPrice;
			UnlockSlotCountOnDefault = unlockSlotCountOnDefault;
		}
		
		public int Capacity { get; }
		public int UnlockSlotPrice { get; }
		public int UnlockSlotCountOnDefault { get; }
	}
}