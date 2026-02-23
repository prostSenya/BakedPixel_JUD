using Services.PersistentProgressServices;

namespace Services.SaveLoadServices
{
	public interface IProgressReader
	{
		void ReadProgress(ProjectProgress projectProgress);
	}
}