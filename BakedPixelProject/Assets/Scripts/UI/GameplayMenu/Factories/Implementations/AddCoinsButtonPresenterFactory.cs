using UI.GameplayMenu.Factories.Interfaces;
using UI.GameplayMenu.Inventories.Buttons.Presenters;
using UI.GameplayMenu.Inventories.Buttons.Presenters.Implementations;
using UI.GameplayMenu.Inventories.Buttons.Presenters.Interfaces;
using UI.GameplayMenu.Inventories.Buttons.Views;
using UI.GameplayMenu.Inventories.Buttons.Views.Interfaces;
using Wallets.Services;

namespace UI.GameplayMenu.Factories.Implementations
{
	public class AddCoinsButtonPresenterFactory : IAddCoinsButtonPresenterFactory
	{
		private readonly IWalletService _walletService;

		public AddCoinsButtonPresenterFactory(IWalletService walletService) =>
			_walletService = walletService;

		public IAddCoinsButtonPresenter Create(IAddCoinsButtonView view) =>
			new AddCoinsButtonPresenter(view, _walletService);
	}
}
