using UnityEngine;

namespace Inventories.Configs
{
	[CreateAssetMenu(fileName = nameof(InventorySlotConfig), menuName = "StaticData/Inventories" + nameof(InventorySlotConfig))]
	public class InventorySlotConfig : ScriptableObject
	{
		[Min(0)]
		[SerializeField] private int _unlockPrice;
		public int UnlockSlotPrice => _unlockPrice;

		[SerializeField] private Sprite _spriteOnLock;
		public Sprite SpriteOnLock => _spriteOnLock;
		
		[SerializeField] private Sprite _spriteOnUnlock;
		public Sprite SpriteOnUnlock => _spriteOnUnlock;
	}
}