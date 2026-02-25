namespace Services.SaveLoadServices
{
	public interface ISaveLoadService
	{
		void SaveProgress();
		void LoadProgress();
		bool HasSavedProgress { get; }
		void RegisterProgressReader(IProgressReader reader);
		void UnregisterProgressReader(IProgressReader reader);
	}
}