using Bullets;
using Inventories.Services;
using Services.RandomServices;
using UI.BaseUI.Implementations;
using UI.GameplayMenu.Inventories.Buttons.Presenters.Interfaces;
using UI.GameplayMenu.Inventories.Buttons.Views.Interfaces;
using UnityEngine;
using Weapons;
using Weapons.Services;

namespace UI.GameplayMenu.Inventories.Buttons.Presenters.Implementations
{
	public class ShootButtonPresenter : Presenter<IShootButtonView>, IShootButtonPresenter
	{
		private readonly IInventoryService _inventoryService;
		private readonly IWeaponService _weaponService;
		private readonly IRandomService _randomService;
		private readonly BulletType[] _bulletTypes;

		public ShootButtonPresenter(
			IShootButtonView shootButton,
			IInventoryService inventoryService,
			IWeaponService weaponService,
			IRandomService randomService,
			BulletType[] bulletTypes)
			: base(shootButton)
		{
			_inventoryService = inventoryService;
			_weaponService = weaponService;
			_randomService = randomService;
			_bulletTypes = bulletTypes;
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

		private void OnClicked()
		{
			BulletType randomBulletType = _randomService.GetRandomElement(_bulletTypes);

			if (_inventoryService.TryGetWeaponByBullet(randomBulletType, out WeaponType weaponType))
			{
				_inventoryService.RemoveBullet(randomBulletType);
				_weaponService.Shoot(randomBulletType, weaponType);
			}
			else if (weaponType == WeaponType.Unknown)
			{
				Debug.LogError($"Cant shoot. No weapon available for bullet type: {randomBulletType}");
			}
		}
	}
}
