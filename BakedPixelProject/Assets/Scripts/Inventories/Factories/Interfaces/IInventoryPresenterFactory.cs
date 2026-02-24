using UI.GameplayMenu.Inventories;
using UnityEngine;

namespace Inventories.Factories
{
	public interface IInventoryPresenterFactory
	{
		InventoryPresenter Create(InventoryView inventoryView, Transform inventorySlotContainer);
	}
}