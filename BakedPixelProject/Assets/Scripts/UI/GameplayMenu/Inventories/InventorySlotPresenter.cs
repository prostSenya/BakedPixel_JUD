using Inventories.Configs;
using Inventories.Domain;
using Services.StaticDataServices;
using UnityEngine;

namespace UI.GameplayMenu.Inventories
{
	public class InventorySlotPresenter
	{
		private readonly InventorySlot _inventorySlot;
		private readonly InventorySlotView _inventorySlotView;
		private readonly IStaticDataService _staticDataService;

		public InventorySlotPresenter(
			InventorySlot inventorySlot, 
			InventorySlotView inventorySlotView, 
			IStaticDataService staticDataService)
		{
			_inventorySlot = inventorySlot;
			_inventorySlotView = inventorySlotView;
			_staticDataService = staticDataService;
		}

		public void Show()
		{
			InventorySlotConfig config = _staticDataService.GetInventorySlotConfig();
			
			Sprite sprite = _inventorySlot.IsLocked 
				? config.SpriteOnLock 
				: config.SpriteOnEmptySlot;

			_inventorySlotView.Initialize(sprite);
		}

		public void Hide()
		{
			
		}
	}
}