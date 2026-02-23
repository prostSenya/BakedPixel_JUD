namespace Services.PersistentProgressServices
{
	public interface IFileProgressStorage
	{
		bool HasData { get; }
		void Save(string json);
		bool TryLoad(out string json);
		void Delete();
	}
}