using System.Collections.Generic;
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
		public List<WeaponConfig> GetWeaponConfig(BulletType bulletType);
		BulletConfig GetBulletConfig(BulletType bulletType);
	}
}