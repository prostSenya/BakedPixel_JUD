using Infrastructure.Initializers;
using Inventories.Factories;
using Inventories.Services;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Wallets.Services;

namespace Infrastructure.Installers
{
	public class GameplaySceneInstaller : MonoInstaller
	{
		[SerializeField] private GameplaySceneUIInitializer _gameplaySceneUIInitializer;

		public override void Install(IContainerBuilder builder)
		{
			builder.RegisterComponent(_gameplaySceneUIInitializer).AsImplementedInterfaces();
			
			builder.Register<IInventoryServiceFactory, InventoryServiceFactory>(Lifetime.Singleton);
			builder.Register<IInventoryPresenterFactory, InventoryPresenterFactory>(Lifetime.Singleton);
			builder.Register<IInventorySlotPresenterFactory, InventorySlotPresenterFactory>(Lifetime.Singleton);

			builder.Register<IInventorySlotViewSpawner, InventorySlotViewSpawner>(Lifetime.Singleton);

			builder.Register<IWalletService, WalletService>(Lifetime.Singleton);
			
			builder.Register<IInventoryService>(
				resolver => resolver.Resolve<IInventoryServiceFactory>().Create(),
				Lifetime.Singleton);
		}
	}
}