using Bullets;
using Inventories.Configs;
using UnityEngine;

namespace Weapons
{
	[CreateAssetMenu(fileName = nameof(WeaponConfig), menuName = "StaticData/Weapons/" + nameof(WeaponConfig))]
	public class WeaponConfig : ScriptableObject
	{
		[SerializeField] private WeaponType _weaponType;
		[SerializeField] private BulletType _uniqueBulletType;
		[SerializeField] private int _damage;
		[SerializeField] private float _weight;

		[Header("Inventory info")] [SerializeField]
		private InventoryItemData _inventoryItemData;

		public int Damage => _damage;
		public WeaponType WeaponType => _weaponType;
		public BulletType UniqueBulletType => _uniqueBulletType;
		public InventoryItemData InventoryItemData => _inventoryItemData;
		public float Weight => _weight;
	}
}