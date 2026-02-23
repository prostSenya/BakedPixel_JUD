using System;
using System.Collections.Generic;
using System.Linq;
using Armors;
using Bullets;
using Inventories.Configs;
using Services.ResourceLoaders;
using Weapons;

namespace Services.StaticDataServices
{
	public class StaticDataService : IStaticDataService
	{
		private const string InventoryConfigPath = "Inventories/InventoryConfig";
		private const string InventorySlotConfigPath = "Inventories/InventorySlotConfig";
		private const string ArmorConfigPath = "Armors";
		private const string WeaponConfigPath = "Weapons";
		private const string BulletConfigPath = "Bullets";
		
		private readonly IResourceLoader _resourceLoader;
		
		private InventoryConfig _inventoryConfig;
		private InventorySlotConfig _inventorySlotConfig;
		private Dictionary<ArmorType, ArmorConfig> _armorConfigs;
		private Dictionary<WeaponType, WeaponConfig> _weaponConfigs;
		private Dictionary<BulletType, BulletConfig> _bulletConfigs;

		public StaticDataService(IResourceLoader resourceLoader) => 
			_resourceLoader = resourceLoader;

		public void LoadAll()
		{
			LoadInventoryConfig();
			LoadInventorySlotConfig();
			LoadArmorConfigs();
			LoadWeaponConfigs();
			LoadBulletConfigs();
		}

		public InventoryConfig GetInventoryConfig() => 
			_inventoryConfig;

		public InventorySlotConfig GetInventorySlotConfig() => 
			_inventorySlotConfig;

		public ArmorConfig GetArmorConfig(ArmorType armorType) => 
			_armorConfigs.TryGetValue(armorType, out var config) 
				? config 
				: throw new ArgumentException($"No config found for {armorType} in {nameof(StaticDataService)}");
		
		public WeaponConfig GetWeaponConfig(WeaponType weaponType) => 
			_weaponConfigs.TryGetValue(weaponType, out var config) 
				? config 
				: throw new ArgumentException($"No config found for {weaponType} in {nameof(StaticDataService)}");

		public BulletConfig GetBulletConfig(BulletType bulletType)
		{
			return _bulletConfigs.TryGetValue(bulletType, out var config) 
				? config 
				: throw new ArgumentException($"No config found for {bulletType} in {nameof(StaticDataService)}");
		}
		
		private void LoadArmorConfigs()
		{
			_armorConfigs = (_resourceLoader.LoadAll<ArmorConfig>(ArmorConfigPath)
			                 ?? 
			                 throw new ArgumentException($"Failed to load {nameof(ArmorConfig)} at path: {ArmorConfigPath}"))
				.ToDictionary(x => x.ArmorType, x => x);
		}
		
		private void LoadWeaponConfigs()
		{
			_weaponConfigs = (_resourceLoader.LoadAll<WeaponConfig>(WeaponConfigPath)
			                  ?? 
			                  throw new ArgumentException($"Failed to load {nameof(WeaponConfig)} at path: {WeaponConfigPath}"))
				.ToDictionary(x => x.WeaponType, x => x);
		}
		
		private void LoadBulletConfigs()
		{
			_bulletConfigs = (_resourceLoader.LoadAll<BulletConfig>(BulletConfigPath)
			                  ?? 
			                  throw new ArgumentException($"Failed to load {nameof(BulletConfig)} at path: {BulletConfigPath}"))
				.ToDictionary(x => x.BulletType, x => x);
		}
		
		private void LoadInventoryConfig()
		{
			_inventoryConfig = _resourceLoader.Load<InventoryConfig>(InventoryConfigPath) 
			                   ??
			                   throw new ArgumentException($"Failed to load {nameof(InventoryConfig)} at path: {InventoryConfigPath}");
		}
		
		private void LoadInventorySlotConfig()
		{
			_inventorySlotConfig = _resourceLoader.Load<InventorySlotConfig>(InventorySlotConfigPath) 
			                       ??
			                       throw new ArgumentException($"Failed to load {nameof(InventorySlotConfig)} at path: {InventorySlotConfigPath}");
		}
	}
}