using Inventories.Domain;
using UI.GameplayMenu.Inventories;
using UnityEngine;

namespace Inventories.Factories.Interfaces
{
	public interface IInventorySlotPresenterFactory
	{
		InventorySlotPresenter Create(IReadOnlyInventorySlot inventorySlot,Transform slotsParent);
	}
}