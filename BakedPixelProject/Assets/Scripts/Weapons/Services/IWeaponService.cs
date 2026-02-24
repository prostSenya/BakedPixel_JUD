using Bullets;

namespace Weapons.Services
{
	public interface IWeaponService
	{
		void Shoot(BulletType bulletType, WeaponType weaponType);
	}
}