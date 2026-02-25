using System;
using UnityEngine;
using Wallets.Services;

namespace UI.GameplayMenu.Buttons
{
	public class AddCoinPresenter : IDisposable
	{
		private readonly AddCoinsButton _addCoinsButton;
		private readonly IWalletService _walletService;

		public AddCoinPresenter(AddCoinsButton addCoinsButton, IWalletService walletService)
		{
			_addCoinsButton = addCoinsButton;
			_walletService = walletService;
		}

		public void Show() => 
			_addCoinsButton.Clicked += OnClicked;

		public void Dispose() => 
			_addCoinsButton.Clicked -= OnClicked;

		private void OnClicked(int amount)
		{
			_walletService.AddMoney(amount);
			Debug.Log($"{_walletService.Money}");
		}
	}
}