using System.Collections.Generic;
using Infrastructure.StateMachines;
using Infrastructure.StateMachines.States.Implementations;
using Inventories.Domain;
using Inventories.Factories.Interfaces;
using Inventories.Services;
using Services.PersistentProgressServices;
using UnityEngine;
using Wallets.Services;

namespace UI.GameplayMenu.Inventories
{
	public class InventoryPresenter 
	{
		private readonly IInventoryService _inventoryService;
		private readonly InventoryView _inventoryView;
		private readonly IInventorySlotPresenterFactory _inventorySlotPresenterFactory;
		private readonly Transform _inventorySlotsContainer;
		private readonly IWalletService _walletService;
		private readonly IGameStateMachine _gameStateMachine;

		private List<InventorySlotPresenter> _inventorySlotPresenters;

		public InventoryPresenter(
			IInventoryService inventoryService, 
			InventoryView inventoryView,
			IInventorySlotPresenterFactory inventorySlotPresenterFactory,
			Transform inventorySlotsContainer,
			IWalletService walletService,
			IGameStateMachine gameStateMachine
			)
		{
			_inventoryService = inventoryService;
			_inventoryView = inventoryView;
			_inventorySlotPresenterFactory = inventorySlotPresenterFactory;
			_inventorySlotsContainer = inventorySlotsContainer;
			_walletService = walletService;
			_gameStateMachine = gameStateMachine;
		}

		public void Show()
		{
			_inventorySlotPresenters = new List<InventorySlotPresenter>(_inventoryService.SlotCount);

			for (int i = 0; i < _inventoryService.SlotCount; i++)
			{
				InventorySlotPresenter inventorySlotPresenter = _inventorySlotPresenterFactory.Create(
					_inventoryService.Slots[i], 
					_inventorySlotsContainer);				
				
				inventorySlotPresenter.Show();
				_inventorySlotPresenters.Add(inventorySlotPresenter);
			}
			
			_walletService.MoneyCountChanged += ChangeCoinText;
			_inventoryView.SaveButtonClicked += SaveProgress; 
			_inventoryView.SetCoinsText(_walletService.Money.ToString());
			_inventoryService.InventaryWeightChanged += ChangeWeightText;
		}

		private void SaveProgress() => 
			_gameStateMachine.Enter<SaveProgressState>();

		private void ChangeWeightText(float weight) => 
			_inventoryView.SetInventoryWeightText(weight.ToString("F1"));

		public void Hide()
		{
			_walletService.MoneyCountChanged -= ChangeCoinText;
			_inventoryView.SaveButtonClicked -= SaveProgress; 

			foreach (InventorySlotPresenter inventorySlotPresenter in _inventorySlotPresenters) 
			 	inventorySlotPresenter.Hide();
		}

		private void ChangeCoinText(int walletMoney) => 
			_inventoryView.SetCoinsText(walletMoney.ToString());
		
		public void WriteProgress(ProjectProgress projectProgress)
		{
			
		}
	}
}