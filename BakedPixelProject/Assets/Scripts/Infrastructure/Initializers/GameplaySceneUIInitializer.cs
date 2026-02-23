using Inventories.Factories;
using UI.GameplayMenu.Inventories;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Initializers
{
	public class GameplaySceneUIInitializer : MonoBehaviour, IInitializable
	{
		[SerializeField] private InventoryView _inventoryView;
		
		private IInventoryFactory _inventoryFactory;

		[Inject]
		private void Construct(IInventoryFactory inventoryFactory)
		{
			_inventoryFactory = inventoryFactory;
		}
		
		public void Initialize()
		{
			Inventory inventory = _inventoryFactory.Create();
			InventoryPresenter inventoryPresenter = new InventoryPresenter(inventory, _inventoryView);
			inventoryPresenter.Show();
		}
	}
}