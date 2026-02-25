using System;
using UnityEngine;

namespace Inventories.Configs
{
	[Serializable]
	public class InventoryItemData
	{
		[SerializeField] private string _name;
		[SerializeField] private string _description;
		[SerializeField] private Sprite _sprite;
		[SerializeField] private InventoryItemType _inventoryItemType;
		
		public string Name => _name;
		public string Description => _description;
		public Sprite Sprite => _sprite;
		public InventoryItemType InventoryItemInventory => _inventoryItemType;
	}
}