using Helpers;
using Inventories.Services;
using Services.RandomServices;
using UI.GameplayMenu.Factories.Interfaces;
using UI.GameplayMenu.Inventories.Buttons.Presenters;
using UI.GameplayMenu.Inventories.Buttons.Presenters.Implementations;
using UI.GameplayMenu.Inventories.Buttons.Presenters.Interfaces;
using UI.GameplayMenu.Inventories.Buttons.Views;
using UI.GameplayMenu.Inventories.Buttons.Views.Interfaces;
using Weapons.Services;

namespace UI.GameplayMenu.Factories.Implementations
{
	public class ShootButtonPresenterFactory : IShootButtonPresenterFactory
	{
		private readonly IInventoryService _inventoryService;
		private readonly IWeaponService _weaponService;
		private readonly IRandomService _randomService;

		public ShootButtonPresenterFactory(
			IInventoryService inventoryService,
			IWeaponService weaponService,
			IRandomService randomService)
		{
			_inventoryService = inventoryService;
			_weaponService = weaponService;
			_randomService = randomService;
		}

		public IShootButtonPresenter Create(IShootButtonView view) =>
			new ShootButtonPresenter(
				view,
				_inventoryService,
				_weaponService,
				_randomService,
				EnumHelper.GetBulletTypes());
	}
}
