using Inventories.Services;
using Services.SaveLoadServices;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Wallets.Services;

namespace Infrastructure.Initializers
{
	public class GameplaySceneSaverInitializer : MonoBehaviour, IInitializable
	{
		private ISaveLoadService _saveLoadService;
		private IInventorySaverServices _inventorySaverServices;
		private IWalletSaverService _walletSaverService;

		[Inject]
		private void Construct(
			ISaveLoadService saveLoadService,
			IInventorySaverServices inventorySaverServices,
			IWalletSaverService walletSaverService)
		{
			_walletSaverService = walletSaverService;
			_inventorySaverServices = inventorySaverServices;
			_saveLoadService = saveLoadService;
		}

		public void Initialize()
		{
			Application.quitting += OnApplicationQuitting;
			_saveLoadService.RegisterProgressReader(_inventorySaverServices);
			_saveLoadService.RegisterProgressReader(_walletSaverService);
		}

		private void OnDestroy()
		{
			Application.quitting -= OnApplicationQuitting;
			_saveLoadService.UnregisterProgressReader(_inventorySaverServices);
			_saveLoadService.UnregisterProgressReader(_walletSaverService);
		}

		private void OnApplicationQuitting()
		{
			_saveLoadService.SaveProgress();
		}
	}
}