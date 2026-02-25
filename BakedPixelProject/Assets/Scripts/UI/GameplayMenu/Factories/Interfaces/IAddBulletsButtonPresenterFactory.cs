using UI.GameplayMenu.Inventories.Buttons.Presenters;
using UI.GameplayMenu.Inventories.Buttons.Presenters.Interfaces;
using UI.GameplayMenu.Inventories.Buttons.Views;
using UI.GameplayMenu.Inventories.Buttons.Views.Interfaces;

namespace UI.GameplayMenu.Factories.Interfaces
{
	public interface IAddBulletsButtonPresenterFactory
	{
		IAddBulletsButtonPresenter Create(IAddBulletsButtonView view);
	}
}
