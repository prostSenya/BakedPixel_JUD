using System;
using Inventories.Configs;
using Services.ResourceLoaders;

namespace Services.StaticDataServices
{
	public class StaticDataService : IStaticDataService
	{
		private const string InventoryConfigPath = "Inventories/InventoryConfig";
		private const string InventorySlotConfigPath = "Inventories/InventorySlotConfig";
		
		private readonly IResourceLoader _resourceLoader;
		
		private InventoryConfig _inventoryConfig;
		private InventorySlotConfig _inventorySlotConfig;

		public StaticDataService(IResourceLoader resourceLoader) => 
			_resourceLoader = resourceLoader;

		public void LoadAll()
		{
			LoadInventoryConfig();
			LoadInventorySlotConfig();
		}

		public InventoryConfig GetInventoryConfig() => 
			_inventoryConfig;

		public InventorySlotConfig GetInventorySlotConfig() => 
			_inventorySlotConfig;

		private void LoadInventoryConfig()
		{
			_inventoryConfig = _resourceLoader.Load<InventoryConfig>(InventoryConfigPath) 
			                   ??
			                   throw new NullReferenceException($"Failed to load InventoryConfig at path: {InventoryConfigPath}");
		}
		
		private void LoadInventorySlotConfig()
		{
			_inventorySlotConfig = _resourceLoader.Load<InventorySlotConfig>(InventorySlotConfigPath) 
			                       ??
			                       throw new NullReferenceException($"Failed to load InventorySlotConfig at path: {InventorySlotConfigPath}");
		}
	}
}