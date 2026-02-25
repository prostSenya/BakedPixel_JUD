using Inventories.Factories.Interfaces;
using Inventories.Services;
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

		public InventoryPresenterFactory(
			IInventoryService inventoryService, 
			IInventorySlotPresenterFactory inventorySlotPresenterFactory,
			IWalletService walletService)
		{
			_inventoryService = inventoryService;
			_inventorySlotPresenterFactory = inventorySlotPresenterFactory;
			_walletService = walletService;
		}

		public InventoryPresenter Create(InventoryView inventoryView, Transform inventorySlotsContainer) => 
			new InventoryPresenter(_inventoryService, inventoryView, _inventorySlotPresenterFactory, inventorySlotsContainer, _walletService);
	}
}