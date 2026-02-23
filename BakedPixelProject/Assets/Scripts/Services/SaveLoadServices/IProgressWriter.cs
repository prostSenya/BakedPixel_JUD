using Services.PersistentProgressServices;

namespace Services.SaveLoadServices
{
	public interface IProgressWriter : IProgressReader
	{
		void WriteProgress(ProjectProgress projectProgress);
	}
}