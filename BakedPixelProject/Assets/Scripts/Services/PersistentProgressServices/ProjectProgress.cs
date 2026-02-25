using System;
using System.Collections.Generic;
using Inventories;

namespace Services.PersistentProgressServices
{
	[Serializable]
	public class ProjectProgress
	{
		public Inventory Inventory;

		public ProjectProgress()
		{ }
	}

	[Serializable]
	public class Inventory
	{
		public List<Slot> Slots;
		public int Money;
		public float Weight;
	}
	
	[Serializable]
	public class Slot
	{
		public int Id;
		public int Amount;
		public ItemKeyData ItemKey;
		public bool IsLocked;

		public Slot(
			int id, 
			int amount,
			ItemKeyData itemKey,
			bool isLocked)
		{
			Id = id;
			Amount = amount;
			ItemKey = itemKey;
			IsLocked = isLocked;
		}
	}
	
	[Serializable]
	public struct ItemKeyData
	{
		public InventoryItemType Type;
		public int EnumItemId;

		public ItemKeyData(InventoryItemType type, int enumItemId)
		{
			Type = type;
			EnumItemId = enumItemId;
		}
	}
}