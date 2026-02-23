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
		[SerializeField] private Transform _inventorySlotContainer;
		
		private IInventoryPresenterFactory _inventoryPresenterFactory;

		[Inject]
		private void Construct(IInventoryPresenterFactory inventoryPresenterFactory) => 
			_inventoryPresenterFactory = inventoryPresenterFactory;

		public void Initialize()
		{
			InventoryPresenter inventoryPresenter = _inventoryPresenterFactory.Create(_inventoryView, _inventorySlotContainer);
			
			inventoryPresenter.Show();
		}
	}
}