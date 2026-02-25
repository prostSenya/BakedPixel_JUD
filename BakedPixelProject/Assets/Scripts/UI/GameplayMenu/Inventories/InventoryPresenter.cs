using System.Collections.Generic;
using Inventories.Domain;
using Inventories.Factories.Interfaces;
using Inventories.Services;
using Services.PersistentProgressServices;
using Services.SaveLoadServices;
using UnityEngine;
using Wallets.Services;

namespace UI.GameplayMenu.Inventories
{
	public class InventoryPresenter : IProgressWriter 
	{
		private readonly IInventoryService _inventoryService;
		private readonly InventoryView _inventoryView;
		private readonly IInventorySlotPresenterFactory _inventorySlotPresenterFactory;
		private readonly Transform _inventorySlotsContainer;
		private readonly IWalletService _walletService;
		private readonly ISaveLoadService _saveLoadService;

		private List<InventorySlotPresenter> _inventorySlotPresenters;

		public InventoryPresenter(
			IInventoryService inventoryService, 
			InventoryView inventoryView,
			IInventorySlotPresenterFactory inventorySlotPresenterFactory,
			Transform inventorySlotsContainer,
			IWalletService walletService, 
			ISaveLoadService saveLoadService
			)
		{
			_saveLoadService = saveLoadService;
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
			_inventoryView.SaveButtonClicked += SaveProgress; 
			_inventoryView.SetCoinsText(_walletService.Money.ToString());
			_inventoryService.InventaryWeightChanged += ChangeWeightText;
		}

		private void SaveProgress() => 
			_saveLoadService.SaveProgress();

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

		public void ReadProgress(ProjectProgress projectProgress)
		{ }

		public void WriteProgress(ProjectProgress projectProgress)
		{
			projectProgress.Inventory.Slots = new List<Slot>(_inventoryService.Slots.Count);
			projectProgress.Inventory.Money = _walletService.Money;
			
			foreach (IReadOnlyInventorySlot slot in _inventoryService.Slots)
			{
				projectProgress.Inventory.Slots.Add(
					new Slot(
						slot.Id, 
						slot.Amount, 
						new ItemKeyData(slot.Key.Type, slot.Key.EnumItemId), 
						slot.IsLocked));
			}
		}
	}
}