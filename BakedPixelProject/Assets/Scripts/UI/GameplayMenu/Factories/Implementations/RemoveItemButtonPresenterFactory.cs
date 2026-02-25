using Inventories.Services;
using UI.GameplayMenu.Factories.Interfaces;
using UI.GameplayMenu.Inventories.Buttons.Presenters;
using UI.GameplayMenu.Inventories.Buttons.Presenters.Implementations;
using UI.GameplayMenu.Inventories.Buttons.Presenters.Interfaces;
using UI.GameplayMenu.Inventories.Buttons.Views;
using UI.GameplayMenu.Inventories.Buttons.Views.Interfaces;

namespace UI.GameplayMenu.Factories.Implementations
{
	public class RemoveItemButtonPresenterFactory : IRemoveItemButtonPresenterFactory
	{
		private readonly IInventoryService _inventoryService;

		public RemoveItemButtonPresenterFactory(IInventoryService inventoryService) =>
			_inventoryService = inventoryService;

		public IRemoveItemButtonPresenter Create(IRemoveItemButtonView view) =>
			new RemoveItemButtonPresenter(view, _inventoryService);
	}
}
