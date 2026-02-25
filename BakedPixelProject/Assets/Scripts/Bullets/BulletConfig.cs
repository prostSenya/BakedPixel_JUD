using Inventories.Configs;
using UnityEngine;

namespace Bullets
{
	[CreateAssetMenu(fileName = nameof(BulletConfig), menuName = "StaticData/Bullets/" + nameof(BulletConfig))]
	public class BulletConfig : ScriptableObject
	{
		[SerializeField] private BulletType _bulletType;
		[SerializeField] private float _weight;
		
		[Header("Inventory info")]
		[SerializeField] private InventoryItemData _inventoryItemData;
		[SerializeField] private int _maxStackCount;
		[SerializeField] private bool _isStackable;
		
		public InventoryItemData InventoryItemData => _inventoryItemData;
		public int MaxStackCount => _maxStackCount;
		public bool IsStackable => _isStackable;
		public BulletType BulletType => _bulletType;
		public float Weight => _weight;
	}
}