using Inventories.Domain;
using UI.GameplayMenu.Inventories;
using UnityEngine;

namespace Inventories.Factories
{
	public interface IInventorySlotPresenterFactory
	{
		InventorySlotPresenter Create(InventorySlot inventorySlot,Transform slotsParent);
	}
}