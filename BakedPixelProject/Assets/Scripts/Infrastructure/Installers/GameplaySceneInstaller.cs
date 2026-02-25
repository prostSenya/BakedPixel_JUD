using Infrastructure.Initializers;
using Inventories.Factories.Implementations;
using Inventories.Factories.Interfaces;
using Inventories.Services;
using Inventories.Spawners;
using UI.GameplayMenu.Factories.Implementations;
using UI.GameplayMenu.Factories.Interfaces;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Wallets.Services;
using Wallets.Services.Factories;

namespace Infrastructure.Installers
{
	public class GameplaySceneInstaller : MonoInstaller
	{
		[SerializeField] private GameplaySceneUIInitializer _gameplaySceneUIInitializer;
		[SerializeField] private GameplaySceneSaverInitializer _gameplaySceneSaverInitializer;

		public override void Install(IContainerBuilder builder)
		{
			builder.RegisterComponent(_gameplaySceneUIInitializer).AsImplementedInterfaces();
			builder.RegisterComponent(_gameplaySceneSaverInitializer).AsImplementedInterfaces();

			builder.Register<IInventoryServiceFactory, InventoryServiceFactory>(Lifetime.Singleton);
			builder.Register<IInventoryPresenterFactory, InventoryPresenterFactory>(Lifetime.Singleton);
			builder.Register<IInventorySlotPresenterFactory, InventorySlotPresenterFactory>(Lifetime.Singleton);
			builder.Register<IAddBulletsButtonPresenterFactory, AddBulletsButtonPresenterFactory>(Lifetime.Singleton);
			builder.Register<IAddCoinsButtonPresenterFactory, AddCoinsButtonPresenterFactory>(Lifetime.Singleton);
			builder.Register<IAddItemButtonPresenterFactory, AddItemButtonPresenterFactory>(Lifetime.Singleton);
			builder.Register<IRemoveItemButtonPresenterFactory, RemoveItemButtonPresenterFactory>(Lifetime.Singleton);
			builder.Register<IShootButtonPresenterFactory, ShootButtonPresenterFactory>(Lifetime.Singleton);

			builder.Register<IInventorySlotViewSpawner, InventorySlotViewSpawner>(Lifetime.Singleton);
			builder.Register<InventorySaverServices>(Lifetime.Singleton).AsImplementedInterfaces();
			builder.Register<IInventoryService>(resolver => resolver.Resolve<IInventoryServiceFactory>().Create(), Lifetime.Singleton);

			builder.Register<IWalletService, WalletService>(Lifetime.Singleton);
			builder.Register<WalletSaverService>(Lifetime.Singleton).AsImplementedInterfaces();
			builder.Register<IWalletServiceFactory, WalletServiceFactory>(Lifetime.Singleton);
			builder.Register<IWalletService>(resolver => resolver.Resolve<IWalletServiceFactory>().Create(), Lifetime.Singleton);
		}
	}
}
