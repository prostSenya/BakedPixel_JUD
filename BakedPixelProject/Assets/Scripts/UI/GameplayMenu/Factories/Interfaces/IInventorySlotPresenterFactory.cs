using Inventories.Domain;
using UI.GameplayMenu.Inventories;
using UI.GameplayMenu.Inventories.Interfaces;
using UnityEngine;

namespace UI.GameplayMenu.Factories.Interfaces
{
	public interface IInventorySlotPresenterFactory
	{
		IInventorySlotPresenter Create(IReadOnlyInventorySlot inventorySlot, Transform slotsParent);
	}
}
