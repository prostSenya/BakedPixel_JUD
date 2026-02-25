using Cysharp.Threading.Tasks;
using Services.SaveLoadServices;
using Services.StaticDataServices;
using UI.SaveViewMenu;
using UnityEngine;

namespace Services.GameplayServices
{
	public class GameplaySaverService : IGameplaySaverService
	{
		private readonly ISaveLoadService _saveLoadService;
		private readonly IStaticDataService _staticDataService;

		public GameplaySaverService(ISaveLoadService saveLoadService, IStaticDataService staticDataService)
		{
			_saveLoadService = saveLoadService;
			_staticDataService = staticDataService;
		}

		public async UniTask Save()
		{
			SaveLoaderView saveLoaderViewprefab = _staticDataService.GetSaveLoaderView();
			SaveLoaderView saveLoaderView = Object.Instantiate(saveLoaderViewprefab);
			_saveLoadService.SaveProgress();
			
			int millisecondsDelay = 1200;
			
			await UniTask.Delay(millisecondsDelay);
			Object.Destroy(saveLoaderView.gameObject);
		}
	}
}