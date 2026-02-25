using UI.GameplayMenu.Inventories;
using UnityEngine;

namespace Inventories.Factories.Interfaces
{
	public interface IInventoryPresenterFactory
	{
		InventoryPresenter Create(InventoryView inventoryView, Transform inventorySlotContainer);
	}
}