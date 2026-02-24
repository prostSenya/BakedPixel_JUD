using System;
using UnityEngine;

namespace Inventories.Domain
{
	public class InventorySlot
	{
		public InventorySlot(int id, bool isLocked)
		{
			Id = id;
			IsLocked = isLocked;
		}

		public int Id { get; }
		public int Count { get; private set; }
		public ItemKey Key { get; private set; }
		public bool IsLocked { get; private set; }
		public bool HasItem => !IsLocked && Key.Type != InventoryItemType.None && Count > 0;

		public void Set(ItemKey key, int count)
		{
			Key = key; 
			Count = count;
			Debug.Log($"InventorySlot {Id} set to {key.Type} (ID: {key.EnumId}) with count {count}");
		}
		
		public void RemoveCount(int count)
		{
			if (Count <= 0)
				return;
			
			Count -= count;

			if (Count <= 0)
			{
				Key = default;
				Count = 0;
			}
		}
		
		public void Unlock() =>
			IsLocked = false;

		public void Clear()
		{
			Key = new ItemKey(InventoryItemType.None, -1);
			Count = 0;
		}

		public readonly struct ItemKey : IEquatable<ItemKey>
		{
			public ItemKey(InventoryItemType type, int enumId)
			{
				Type = type; 
				EnumId = enumId;
			}
			
			public InventoryItemType Type { get; }
			public int EnumId { get; }

			public bool Equals(ItemKey other)
			{
				return Type == other.Type && EnumId == other.EnumId;
			}

			public override bool Equals(object obj)
			{
				return obj is ItemKey other && Equals(other);
			}

			public override int GetHashCode()
			{
				return HashCode.Combine((int)Type, EnumId);
			}
		}
	}
}