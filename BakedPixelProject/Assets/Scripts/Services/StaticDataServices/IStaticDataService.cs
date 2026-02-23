using Armors;
using Bullets;
using Inventories.Configs;
using Weapons;

namespace Services.StaticDataServices
{
	public interface IStaticDataService
	{
		InventoryConfig GetInventoryConfig();
		void LoadAll();
		InventorySlotConfig GetInventorySlotConfig();
		ArmorConfig GetArmorConfig(ArmorType armorType);
		WeaponConfig GetWeaponConfig(WeaponType weaponType);
		BulletConfig GetBulletConfig(BulletType bulletType);
	}
}