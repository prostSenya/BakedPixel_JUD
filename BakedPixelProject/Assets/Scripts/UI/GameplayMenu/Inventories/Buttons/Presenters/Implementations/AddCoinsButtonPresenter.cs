using UI.BaseUI.Implementations;
using UI.GameplayMenu.Inventories.Buttons.Presenters.Interfaces;
using UI.GameplayMenu.Inventories.Buttons.Views.Interfaces;
using UnityEngine;
using Wallets.Services;

namespace UI.GameplayMenu.Inventories.Buttons.Presenters.Implementations
{
	public class AddCoinsButtonPresenter : Presenter<IAddCoinsButtonView>, IAddCoinsButtonPresenter
	{
		private readonly IWalletService _walletService;

		public AddCoinsButtonPresenter(IAddCoinsButtonView addCoinsButton, IWalletService walletService)
			: base(addCoinsButton)
		{
			_walletService = walletService;
		}

		public override void Activate()
		{
			base.Activate();
			View.Clicked += OnClicked;
		}

		public override void Deactivate()
		{
			View.Clicked -= OnClicked;
			base.Deactivate();
		}

		private void OnClicked(int amount)
		{
			_walletService.AddMoney(amount);
			Debug.Log($"{_walletService.Money}");
		}
	}
}
