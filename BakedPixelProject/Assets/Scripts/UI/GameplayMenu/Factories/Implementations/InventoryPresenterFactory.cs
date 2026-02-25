using Infrastructure.StateMachines;
using Inventories.Services;
using UI.GameplayMenu.Factories.Interfaces;
using UI.GameplayMenu.Inventories;
using UI.GameplayMenu.Inventories.Implementations;
using UI.GameplayMenu.Inventories.Interfaces;
using UnityEngine;
using Wallets.Services;

namespace UI.GameplayMenu.Factories.Implementations
{
	public class InventoryPresenterFactory : IInventoryPresenterFactory
	{
		private readonly IInventoryService _inventoryService;
		private readonly IInventorySlotPresenterFactory _inventorySlotPresenterFactory;
		private readonly IWalletService _walletService;
		private readonly IGameStateMachine _gameStateMachine;

		public InventoryPresenterFactory(
			IInventoryService inventoryService,
			IInventorySlotPresenterFactory inventorySlotPresenterFactory,
			IWalletService walletService,
			IGameStateMachine gameStateMachine)
		{
			_inventoryService = inventoryService;
			_inventorySlotPresenterFactory = inventorySlotPresenterFactory;
			_walletService = walletService;
			_gameStateMachine = gameStateMachine;
		}

		public IInventoryPresenter Create(IInventoryView inventoryView, Transform inventorySlotsContainer) =>
			new InventoryPresenter(
				_inventoryService,
				inventoryView,
				_inventorySlotPresenterFactory,
				inventorySlotsContainer,
				_walletService,
				_gameStateMachine);
	}
}
