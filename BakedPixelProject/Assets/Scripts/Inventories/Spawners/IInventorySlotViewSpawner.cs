using UI.GameplayMenu.Inventories;
using UnityEngine;

namespace Inventories.Factories
{
	public interface IInventorySlotViewSpawner
	{
		InventorySlotView Spawn(Transform parent);
	}
}