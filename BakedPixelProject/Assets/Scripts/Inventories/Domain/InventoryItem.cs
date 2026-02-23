namespace Inventories.Domain
{
	public class InventoryItem
	{
		public InventoryItem(string name, string description, InventoryItemType itemType = InventoryItemType.None)
		{
			Name = name;
			Description = description;
			ItemType = itemType;
		}

		public string Name { get; }
		public string Description { get; }
		public InventoryItemType ItemType { get; }
	}
}