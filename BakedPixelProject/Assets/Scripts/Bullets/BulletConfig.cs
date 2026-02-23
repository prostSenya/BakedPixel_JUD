using Inventories.Configs;
using UnityEngine;

namespace Bullets
{
	public class BulletConfig : MonoBehaviour
	{
		[SerializeField] private BulletType _bulletType;
		[SerializeField] private float _weight;
		
		[Header("Inventory info")]
		[SerializeField] private InventoryItemData _inventoryItemData;
	}
}