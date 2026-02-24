using Infrastructure.Initializers;
using Inventories.Domain;
using Inventories.Factories;
using Inventories.Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Installers
{
	public class GameplaySceneInstaller : MonoInstaller
	{
		[SerializeField] private GameplaySceneUIInitializer _gameplaySceneUIInitializer;

		public override void Install(IContainerBuilder builder)
		{
			builder.RegisterComponent(_gameplaySceneUIInitializer).AsImplementedInterfaces();

			builder.Register( resolver =>
				resolver.Resolve<IInventoryFactory>().Create(), Lifetime.Singleton);

			builder.Register<IInventoryFactory, InventoryFactory>(Lifetime.Singleton);
			builder.Register<IInventorySlotFactory, InventorySlotFactory>(Lifetime.Singleton);
			builder.Register<IInventoryPresenterFactory, InventoryPresenterFactory>(Lifetime.Singleton);
			builder.Register<IInventorySlotPresenterFactory, InventorySlotPresenterFactory>(Lifetime.Singleton);
			
			builder.Register<IInventorySlotViewSpawner, InventorySlotViewSpawner>(Lifetime.Singleton);
			
			builder.Register<IInventoryService, InventoryService>(Lifetime.Singleton);
		}
	}
}