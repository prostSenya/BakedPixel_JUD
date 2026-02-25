using Services.SaveLoadServices;

namespace Services.GameplayServices
{
	public class GameplaySaverService : IGameplaySaverService
	{
		private readonly ISaveLoadService _saveLoadService;

		public GameplaySaverService(ISaveLoadService saveLoadService)
		{
			_saveLoadService = saveLoadService;
		}

		public void Save()
		{
			_saveLoadService.SaveProgress();
		}
	}
}