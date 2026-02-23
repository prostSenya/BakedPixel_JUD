using Inventories.Domain;
using Inventories.Factories;
using Services.StaticDataServices;
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
		
		private IInventoryFactory _inventoryFactory;
		private IInventorySlotContainerProvider _inventorySlotContainerProvider;
		private IInventorySlotFactory _inventorySlotFactory;
		private IInventorySlotViewSpawner _inventoryViewSpawner;
		private IStaticDataService _staticDataService;

		[Inject]
		private void Construct(
			IInventoryFactory inventoryFactory, 
			IInventorySlotContainerProvider inventorySlotContainerProvider,
			IInventorySlotFactory inventorySlotFactory,
			IInventorySlotViewSpawner inventoryViewSpawner,
			IStaticDataService staticDataService)
		{
			_staticDataService = staticDataService;
			_inventoryFactory = inventoryFactory;
			_inventorySlotContainerProvider = inventorySlotContainerProvider;
			_inventorySlotFactory = inventorySlotFactory;
			_inventoryViewSpawner = inventoryViewSpawner;
		}
		
		public void Initialize()
		{
			_inventorySlotContainerProvider.SetSlotContainer(_inventorySlotContainer);
			
			Inventory inventory = _inventoryFactory.Create();
			InventoryPresenter inventoryPresenter = new InventoryPresenter(
				inventory, 
				_inventoryView, 
				_inventorySlotFactory, 
				_inventoryViewSpawner,
				_staticDataService);
			
			inventoryPresenter.Show();
		}
	}
}