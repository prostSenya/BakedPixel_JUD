using UI.GameplayMenu.Inventories;
using UI.GameplayMenu.Inventories.Implementations;
using UnityEngine;

namespace Inventories.Configs
{
	[CreateAssetMenu(fileName = nameof(InventorySlotConfig), menuName = "StaticData/Inventories/" + nameof(InventorySlotConfig))]
	public class InventorySlotConfig : ScriptableObject
	{
		[Min(0)]
		[SerializeField] private int _unlockPrice;
		public int UnlockSlotPrice => _unlockPrice;

		[SerializeField] private Sprite _spriteOnLock;
		public Sprite SpriteOnLock => _spriteOnLock;
		
		[SerializeField] private Sprite _spriteOnEmptySlot;
		public Sprite SpriteOnEmptySlot => _spriteOnEmptySlot;
		
		[SerializeField] private InventorySlotView _prefab;
		public InventorySlotView Prefab => _prefab;
	}
}