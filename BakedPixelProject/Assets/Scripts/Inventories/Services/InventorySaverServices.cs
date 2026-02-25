using System.Collections.Generic;
using Inventories.Domain;
using Services.PersistentProgressServices;

namespace Inventories.Services
{
	public class InventorySaverServices : IInventorySaverServices
	{
		private readonly IInventoryService _inventoryService;

		public InventorySaverServices(IInventoryService inventoryService)
		{
			_inventoryService = inventoryService;
		}

		public void ReadProgress(ProjectProgress projectProgress)
		{ }

		public void WriteProgress(ProjectProgress projectProgress)
		{
			if (projectProgress.Inventory == null) 
				projectProgress.Inventory = new Inventory();
			
			projectProgress.Inventory.Slots = new List<Slot>(_inventoryService.Slots.Count);
			projectProgress.Inventory.Weight = _inventoryService.InventoryWeight;
			
			foreach (IReadOnlyInventorySlot slot in _inventoryService.Slots)
			{
				projectProgress.Inventory.Slots.Add(
					new Slot(
						slot.Id, 
						slot.Amount, 
						new ItemKeyData(slot.Key.Type, slot.Key.EnumItemId), 
						slot.IsLocked));
			}
		}
	}
}