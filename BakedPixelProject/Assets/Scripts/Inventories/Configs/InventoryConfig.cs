using UnityEngine;

namespace Inventories.Configs
{
	[CreateAssetMenu(fileName = nameof(InventoryConfig), menuName = "StaticData/Inventories" + nameof(InventoryConfig))]
	public class InventoryConfig : ScriptableObject
	{
		[Min(0)]
		[SerializeField] private int _capacity;
		
		[Min(0)]
		[SerializeField] private int _unlockSlotCountOnDefault;
		
#if UNITY_EDITOR
		private void OnValidate()
		{
			if (_unlockSlotCountOnDefault > _capacity)
				_unlockSlotCountOnDefault = _capacity;
		}
#endif
		
		public int Capacity => _capacity; 
		public int UnlockSlotCountOnDefault => _unlockSlotCountOnDefault;
	}
}
