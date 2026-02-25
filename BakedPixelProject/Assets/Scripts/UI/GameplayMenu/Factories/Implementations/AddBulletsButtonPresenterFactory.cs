using Helpers;
using Inventories.Services;
using UI.GameplayMenu.Factories.Interfaces;
using UI.GameplayMenu.Inventories.Buttons.Presenters;
using UI.GameplayMenu.Inventories.Buttons.Presenters.Implementations;
using UI.GameplayMenu.Inventories.Buttons.Presenters.Interfaces;
using UI.GameplayMenu.Inventories.Buttons.Views;
using UI.GameplayMenu.Inventories.Buttons.Views.Interfaces;

namespace UI.GameplayMenu.Factories.Implementations
{
	public class AddBulletsButtonPresenterFactory : IAddBulletsButtonPresenterFactory
	{
		private readonly IInventoryService _inventoryService;

		public AddBulletsButtonPresenterFactory(IInventoryService inventoryService) =>
			_inventoryService = inventoryService;

		public IAddBulletsButtonPresenter Create(IAddBulletsButtonView view) =>
			new AddBulletsButtonPresenter(_inventoryService, view, EnumHelper.GetBulletTypes());
	}
}
