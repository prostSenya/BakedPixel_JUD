using System;
using System.Linq;
using Bullets;
using Helpers;
using Inventories.Services;
using Services.RandomServices;
using UnityEngine;
using Weapons;
using Weapons.Services;

namespace UI.GameplayMenu.Buttons
{
	public class ShootPresenter : IDisposable
	{
		private readonly ShootButton _shootButton;
		private readonly IInventoryService _inventoryService;
		private readonly IWeaponService _weaponService;
		private readonly IRandomService _randomService;
		private readonly BulletType[] _bulletTypes;

		public ShootPresenter(
			ShootButton shootButton, 
			IInventoryService inventoryService, 
			IWeaponService weaponService,
			IRandomService randomService,
			BulletType[] bulletTypes)
		{
			_shootButton = shootButton;
			_inventoryService = inventoryService;
			_weaponService = weaponService;
			_randomService = randomService;
			_bulletTypes = bulletTypes;
		}

		public void Show() => 
			_shootButton.Clicked += OnClicked;

		public void Dispose() => 
			_shootButton.Clicked -= OnClicked;

		private void OnClicked()
		{
			BulletType randomBulletType = _randomService.GetRandomElement(_bulletTypes);

			if (_inventoryService.TryGetWeaponByBullet(randomBulletType, out WeaponType weaponType))
			{
				_inventoryService.RemoveBullet(randomBulletType);
				_weaponService.Shoot(randomBulletType, weaponType);
			}
			else
			{
				Debug.LogError($"Cannt shoot. No weapon available for bullet type: {randomBulletType}");
			}
		}
	}
}