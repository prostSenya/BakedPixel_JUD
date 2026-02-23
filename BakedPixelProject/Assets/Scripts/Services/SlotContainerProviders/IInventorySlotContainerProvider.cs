using UnityEngine;

namespace Inventories.Factories
{
	public interface IInventorySlotContainerProvider
	{
		void SetSlotContainer(Transform slotContainer);
		Transform GetSlotContainer();
	}
}