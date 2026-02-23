using System;
using Inventories.Configs;
using Services.ResourceLoaders;

namespace Services.StaticDataServices
{
	public class StaticDataService : IStaticDataService
	{
		private const string InventoryConfigPath = "Inventories/InventoryConfig";
		
		private readonly IResourceLoader _resourceLoader;
		
		private InventoryConfig _inventoryConfig;

		public StaticDataService(IResourceLoader resourceLoader) => 
			_resourceLoader = resourceLoader;

		public void LoadAll()
		{
			LoadInventoryConfig();
		}

		public InventoryConfig GetInventoryConfig() => 
			_inventoryConfig;

		private void LoadInventoryConfig()
		{
			_inventoryConfig = _resourceLoader.Load<InventoryConfig>(InventoryConfigPath) 
			                   ??
			                   throw new NullReferenceException($"Failed to load InventoryConfig at path: {InventoryConfigPath}");
		}
	}
}