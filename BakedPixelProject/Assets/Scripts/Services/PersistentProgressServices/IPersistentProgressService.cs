namespace Services.PersistentProgressServices
{
	public interface IPersistentProgressService
	{
		ProjectProgress ProjectProgress { get; }
		void LoadProgress(string json);
		void SetDefaultProgress();
	}
}