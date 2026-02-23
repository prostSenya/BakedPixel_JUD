using Inventories.Domain;
using Inventories.Factories;
using Services.StaticDataServices;

namespace UI.GameplayMenu.Inventories
{
	public class InventoryPresenter
	{
		private readonly Inventory _inventory;
		private readonly InventoryView _inventoryView;
		private readonly IInventorySlotFactory _inventorySlotFactory;
		private readonly IInventorySlotViewSpawner _inventoryViewSpawner;
		private readonly IStaticDataService _staticDataService;

		public InventoryPresenter(
			Inventory inventory, 
			InventoryView inventoryView, 
			IInventorySlotFactory inventorySlotFactory,
			IInventorySlotViewSpawner inventoryViewSpawner,
			IStaticDataService staticDataService)
		{
			_inventory = inventory;
			_inventoryView = inventoryView;
			_inventorySlotFactory = inventorySlotFactory;
			_inventoryViewSpawner = inventoryViewSpawner;
			_staticDataService = staticDataService;
		}
		
		public void Show()
		{
			for (int i = 0; i < _inventory.InventorySlotCount; i++)
			{
				InventorySlotPresenter inventorySlotPresenter = new InventorySlotPresenter(
					_inventorySlotFactory.Create(),
					_inventoryViewSpawner.Spawn(_inventory.InventorySlotCount),
					_staticDataService	
					);
			}
			;
			//_inventoryView.Show();
		}
		
		public void Hide()
		{
			//_inventoryView.Hide();
		}
	}
}