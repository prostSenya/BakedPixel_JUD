using Services.JsonConvertServices;

namespace Services.PersistentProgressServices
{
	public class PersistentProgressService : IPersistentProgressService
	{
		private readonly IJsonConvertService _jsonConvertService;

		public PersistentProgressService(IJsonConvertService jsonConvertService) => 
			_jsonConvertService = jsonConvertService;

		public ProjectProgress ProjectProgress { get; private set; }

		public void LoadProgress(string json) => 
			ProjectProgress = _jsonConvertService.FromJson<ProjectProgress>(json);

		public void SetDefaultProgress()
		{
		}
	}
}