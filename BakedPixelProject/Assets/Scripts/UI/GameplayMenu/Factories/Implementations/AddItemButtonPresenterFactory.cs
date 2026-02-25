using System;
using System.Linq;
using Helpers;
using Inventories;
using Inventories.Services;
using Services.RandomServices;
using Services.StaticDataServices;
using UI.GameplayMenu.Factories.Interfaces;
using UI.GameplayMenu.Inventories.Buttons.Presenters;
using UI.GameplayMenu.Inventories.Buttons.Presenters.Implementations;
using UI.GameplayMenu.Inventories.Buttons.Presenters.Interfaces;
using UI.GameplayMenu.Inventories.Buttons.Views;
using UI.GameplayMenu.Inventories.Buttons.Views.Interfaces;

namespace UI.GameplayMenu.Factories.Implementations
{
	public class AddItemButtonPresenterFactory : IAddItemButtonPresenterFactory
	{
		private readonly IInventoryService _inventoryService;
		private readonly IRandomService _randomService;
		private readonly IStaticDataService _staticDataService;

		public AddItemButtonPresenterFactory(
			IInventoryService inventoryService,
			IRandomService randomService,
			IStaticDataService staticDataService)
		{
			_inventoryService = inventoryService;
			_randomService = randomService;
			_staticDataService = staticDataService;
		}

		public IAddItemButtonPresenter Create(IAddItemButtonView view)
		{
			InventoryItemType[] inventoryItemTypes = Enum.GetValues(typeof(InventoryItemType))
				.Cast<InventoryItemType>()
				.Where(type =>
					type != InventoryItemType.Unknown &&
					type != InventoryItemType.Ammo &&
					type != InventoryItemType.Empty)
				.ToArray();

			return new AddItemButtonPresenter(
				view,
				_inventoryService,
				_randomService,
				_staticDataService,
				inventoryItemTypes,
				EnumHelper.GetWeaponTypes());
		}
	}
}
