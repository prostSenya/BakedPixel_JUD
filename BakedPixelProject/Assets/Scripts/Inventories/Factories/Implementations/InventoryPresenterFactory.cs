using Inventories.Factories.Interfaces;
using Inventories.Services;
using Services.SaveLoadServices;
using UI.GameplayMenu.Inventories;
using UnityEngine;
using Wallets.Services;

namespace Inventories.Factories.Implementations
{
	public class InventoryPresenterFactory : IInventoryPresenterFactory
	{
		private readonly IInventoryService _inventoryService;
		private readonly IInventorySlotPresenterFactory _inventorySlotPresenterFactory;
		private readonly IWalletService _walletService;
		private readonly ISaveLoadService _saveLoadService;

		public InventoryPresenterFactory(
			IInventoryService inventoryService, 
			IInventorySlotPresenterFactory inventorySlotPresenterFactory,
			IWalletService walletService,
			ISaveLoadService saveLoadService
			)
		{
			_inventoryService = inventoryService;
			_inventorySlotPresenterFactory = inventorySlotPresenterFactory;
			_walletService = walletService;
			_saveLoadService = saveLoadService;
		}

		public InventoryPresenter Create(InventoryView inventoryView, Transform inventorySlotsContainer) => 
			new InventoryPresenter(
				_inventoryService, 
				inventoryView, 
				_inventorySlotPresenterFactory,
				inventorySlotsContainer, 
				_walletService,
				_saveLoadService);
	}
}