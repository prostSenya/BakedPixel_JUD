using System.Collections.Generic;
using Infrastructure.StateMachines;
using Infrastructure.StateMachines.States.Implementations;
using Inventories.Services;
using Services.PersistentProgressServices;
using UI.BaseUI.Implementations;
using UI.GameplayMenu.Factories.Interfaces;
using UI.GameplayMenu.Inventories.Interfaces;
using UnityEngine;
using Wallets.Services;

namespace UI.GameplayMenu.Inventories.Implementations
{
	public class InventoryPresenter : Presenter<IInventoryView>, IInventoryPresenter
	{
		private readonly IInventoryService _inventoryService;
		private readonly IInventorySlotPresenterFactory _inventorySlotPresenterFactory;
		private readonly Transform _inventorySlotsContainer;
		private readonly IWalletService _walletService;
		private readonly IGameStateMachine _gameStateMachine;

		private List<IInventorySlotPresenter> _inventorySlotPresenters;

		public InventoryPresenter(
			IInventoryService inventoryService,
			IInventoryView inventoryView,
			IInventorySlotPresenterFactory inventorySlotPresenterFactory,
			Transform inventorySlotsContainer,
			IWalletService walletService,
			IGameStateMachine gameStateMachine)
			: base(inventoryView)
		{
			_inventoryService = inventoryService;
			_inventorySlotPresenterFactory = inventorySlotPresenterFactory;
			_inventorySlotsContainer = inventorySlotsContainer;
			_walletService = walletService;
			_gameStateMachine = gameStateMachine;
		}

		public override void Activate()
		{
			base.Activate();
			EnsureSlotPresenters();

			foreach (IInventorySlotPresenter inventorySlotPresenter in _inventorySlotPresenters)
				inventorySlotPresenter.Activate();

			_walletService.MoneyCountChanged += ChangeCoinText;
			View.SaveButtonClicked += SaveProgress;
			_inventoryService.InventaryWeightChanged += ChangeWeightText;
			View.SetCoinsText(_walletService.Money.ToString());
			View.SetInventoryWeightText(_inventoryService.InventoryWeight.ToString("F1"));
		}

		public override void Deactivate()
		{
			_walletService.MoneyCountChanged -= ChangeCoinText;
			View.SaveButtonClicked -= SaveProgress;
			_inventoryService.InventaryWeightChanged -= ChangeWeightText;

			if (_inventorySlotPresenters != null)
			{
				foreach (IInventorySlotPresenter inventorySlotPresenter in _inventorySlotPresenters)
					inventorySlotPresenter.Deactivate();
			}

			base.Deactivate();
		}

		private void EnsureSlotPresenters()
		{
			if (_inventorySlotPresenters != null)
				return;

			_inventorySlotPresenters = new List<IInventorySlotPresenter>(_inventoryService.SlotCount);

			for (int i = 0; i < _inventoryService.SlotCount; i++)
			{
				IInventorySlotPresenter inventorySlotPresenter = _inventorySlotPresenterFactory.Create(
					_inventoryService.Slots[i],
					_inventorySlotsContainer);

				_inventorySlotPresenters.Add(inventorySlotPresenter);
			}
		}

		private void SaveProgress() =>
			_gameStateMachine.Enter<SaveProgressState>();

		private void ChangeWeightText(float weight) =>
			View.SetInventoryWeightText(weight.ToString("F1"));

		private void ChangeCoinText(int walletMoney) =>
			View.SetCoinsText(walletMoney.ToString());

		public void WriteProgress(ProjectProgress projectProgress)
		{ }
	}
}
