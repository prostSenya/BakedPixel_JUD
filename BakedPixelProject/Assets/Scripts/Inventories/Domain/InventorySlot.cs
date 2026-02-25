using System;
using UnityEngine;

namespace Inventories.Domain
{
	public class InventorySlot : IReadOnlyInventorySlot
	{
		public InventorySlot(int id, bool isLocked)
		{
			Id = id;
			IsLocked = isLocked;
			Key = ItemKey.CreateEmptyItem();
		}

		public float Weight { get; private set; }
		public int Id { get; }
		public int Amount { get; private set; }
		public ItemKey Key { get; private set; }
		public bool IsLocked { get; private set; }
		public bool HasItem => IsLocked == false && 
		                       Key.Type != InventoryItemType.Empty && Amount > 0;

		public event Action ItemSetted;
		public event Action ItemRemoved;
		public event Action Cleared;
		public void Set(ItemKey key, int count, float weight)
		{
			Weight = weight;
			Key = key; 
			Amount = count;
			Debug.Log($"InventorySlot {Id} set to {key.Type} (ID: {key.EnumItemId}) with count {count}");
			ItemSetted?.Invoke();
		}
		
		public void RemoveCount(int count)
		{
			if (Amount <= 0)
				return;
			
			Amount -= count;

			if (Amount <= 0)
			{
				Key = ItemKey.CreateEmptyItem();
				Amount = 0;
			}
			
			ItemRemoved?.Invoke();
		}
		
		public void Unlock() =>
			IsLocked = false;

		public void Clear()
		{
			Cleared?.Invoke();
			Key = new ItemKey(InventoryItemType.Empty, -1);
			Amount = 0;
		}
	}
	
	public readonly struct ItemKey : IEquatable<ItemKey>
	{
		public ItemKey(InventoryItemType type, int enumItemId)
		{
			Type = type; 
			EnumItemId = enumItemId;
		}
			
		public InventoryItemType Type { get; }
		public int EnumItemId { get; }

		public bool Equals(ItemKey other)
		{
			return Type == other.Type && EnumItemId == other.EnumItemId;
		}

		public override bool Equals(object obj)
		{
			return obj is ItemKey other && Equals(other);
		}

		public override int GetHashCode()
		{
			return HashCode.Combine((int)Type, EnumItemId);
		}

		public static ItemKey CreateEmptyItem() => 
			new(InventoryItemType.Empty, -1);
	}
}