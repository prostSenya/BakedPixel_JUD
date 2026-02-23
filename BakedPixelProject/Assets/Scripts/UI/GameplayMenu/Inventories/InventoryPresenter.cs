using Inventories.Domain;
using UnityEngine;

namespace UI.GameplayMenu.Inventories
{
	public class InventoryPresenter
	{
		private readonly Inventory _inventory;
		private readonly InventoryView _inventoryView;

		public InventoryPresenter(Inventory inventory, InventoryView inventoryView)
		{
			_inventory = inventory;
			_inventoryView = inventoryView;
		}
		
		public void Show()
		{
			Debug.Log("Show inventory");
			//_inventoryView.Show();
		}
		
		public void Hide()
		{
			//_inventoryView.Hide();
		}
	}
}