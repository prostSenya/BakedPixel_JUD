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
	}
}