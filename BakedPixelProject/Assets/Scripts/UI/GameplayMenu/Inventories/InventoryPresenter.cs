using System.Collections.Generic;
using Inventories.Factories.Interfaces;
using Inventories.Services;
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

		private List<InventorySlotPresenter> _inventorySlotPresenters;

		public InventoryPresenter(
			IInventoryService inventoryService, 
			InventoryView inventoryView,
			IInventorySlotPresenterFactory inventorySlotPresenterFactory,
			Transform inventorySlotsContainer,
			IWalletService walletService)
		{
			_inventoryService = inventoryService;
			_inventoryView = inventoryView;
			_inventorySlotPresenterFactory = inventorySlotPresenterFactory;
			_inventorySlotsContainer = inventorySlotsContainer;
			_walletService = walletService;
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
			_inventoryView.SetCoinsText(_walletService.Money.ToString());
			_inventoryService.InventaryWeightChanged += ChangeWeightText;
		}

		private void ChangeWeightText(float weight) => 
			_inventoryView.SetInventoryWeightText(weight.ToString("F1"));

		public void Hide()
		{
			_walletService.MoneyCountChanged -= ChangeCoinText;

			foreach (InventorySlotPresenter inventorySlotPresenter in _inventorySlotPresenters) 
			 	inventorySlotPresenter.Hide();
		}

		private void ChangeCoinText(int walletMoney) => 
			_inventoryView.SetCoinsText(walletMoney.ToString());
	}
}