using Inventories.Configs;
using UnityEngine;

namespace Armors
{
	[CreateAssetMenu(fileName = nameof(ArmorConfig), menuName = "StaticData/Armors/" + nameof(ArmorConfig))]
	public class ArmorConfig : ScriptableObject
	{
		[SerializeField] private ArmorType _armorType;
		[SerializeField] private float _weight;
		[SerializeField] private float _defense;

		[Header("Inventory info")]
		[SerializeField] private InventoryItemData _inventoryItemData;

		public ArmorType ArmorType => _armorType;
	}
}