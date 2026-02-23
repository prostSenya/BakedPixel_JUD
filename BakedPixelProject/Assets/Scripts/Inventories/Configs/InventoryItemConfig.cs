using UnityEngine;

namespace Inventories.Configs
{
	[CreateAssetMenu(fileName = nameof(InventoryItemConfig), menuName = "StaticData/Inventories" + nameof(InventoryItemConfig))]
	public class InventoryItemConfig : ScriptableObject
	{
		[SerializeField] private InventoryItemType _inventoryItemType;

		[SerializeField] private Sprite _sprite;

		[Min(0)]
		[SerializeField] private float _weight;

		[Min(0)]
		[SerializeField] private int _damage;

		public float Weight => _weight; 
		public int Damage => _damage;
	}
}