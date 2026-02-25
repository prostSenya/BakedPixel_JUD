using UI.GameplayMenu.Inventories;
using UI.GameplayMenu.Inventories.Interfaces;
using UnityEngine;

namespace Inventories.Spawners
{
	public interface IInventorySlotViewSpawner
	{
		IInventorySlotView Spawn(Transform parent);
	}
}
