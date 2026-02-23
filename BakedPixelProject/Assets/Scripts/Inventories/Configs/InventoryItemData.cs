using System;
using UnityEngine;

namespace Inventories.Configs
{
	[Serializable]
	public class InventoryItemData
	{
		[SerializeField] private string _name;
		[SerializeField] private string _description;
		[SerializeField] private InventoryItemType _itemType;
		[SerializeField] private Sprite _sprite;
	}
}