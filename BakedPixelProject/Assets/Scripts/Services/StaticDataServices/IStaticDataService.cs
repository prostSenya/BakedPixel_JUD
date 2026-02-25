using System.Collections.Generic;
using Armors;
using Bullets;
using Inventories.Configs;
using UI.SaveViewMenu;
using Weapons;

namespace Services.StaticDataServices
{
	public interface IStaticDataService
	{
		InventoryConfig GetInventoryConfig();
		void LoadAll();
		InventorySlotConfig GetInventorySlotConfig();
		ArmorConfig GetArmorConfig(ArmorType armorType);
		List<ArmorConfig> GetTorsoArmorConfigs();
		List<ArmorConfig> GetHeadArmorConfigs();
		WeaponConfig GetWeaponConfig(WeaponType weaponType);
		public List<WeaponConfig> GetWeaponConfig(BulletType bulletType);
		BulletConfig GetBulletConfig(BulletType bulletType);
		SaveLoaderView GetSaveLoaderView();
	}
}