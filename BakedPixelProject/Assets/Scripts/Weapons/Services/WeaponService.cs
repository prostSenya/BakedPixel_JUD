using Bullets;
using Services.StaticDataServices;
using UnityEngine;

namespace Weapons.Services
{
	public class WeaponService : IWeaponService
	{
		private readonly IStaticDataService _staticDataService;

		public WeaponService(IStaticDataService staticDataService)
		{
			_staticDataService = staticDataService;
		}
		
		public void Shoot(BulletType bulletType, WeaponType weaponType)
		{
			BulletConfig bulletConfig = _staticDataService.GetBulletConfig(bulletType);
			WeaponConfig weaponConfig = _staticDataService.GetWeaponConfig(weaponType);
			
			Debug.Log($"Shoted from {weaponConfig.InventoryItemData.Name}, with {bulletConfig.InventoryItemData.Name}, damage: {weaponConfig.Damage}");
		}
	}
}