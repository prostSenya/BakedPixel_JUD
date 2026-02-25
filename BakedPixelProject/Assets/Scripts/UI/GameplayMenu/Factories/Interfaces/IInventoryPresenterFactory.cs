using UI.GameplayMenu.Inventories;
using UI.GameplayMenu.Inventories.Interfaces;
using UnityEngine;

namespace UI.GameplayMenu.Factories.Interfaces
{
	public interface IInventoryPresenterFactory
	{
		IInventoryPresenter Create(IInventoryView inventoryView, Transform inventorySlotContainer);
	}
}
