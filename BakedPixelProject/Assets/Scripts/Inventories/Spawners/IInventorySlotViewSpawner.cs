using UI.GameplayMenu.Inventories;
using UnityEngine;

namespace Inventories.Spawners
{
	public interface IInventorySlotViewSpawner
	{
		InventorySlotView Spawn(Transform parent);
	}
}