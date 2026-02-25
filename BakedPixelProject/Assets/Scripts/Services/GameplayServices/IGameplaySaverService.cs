using Cysharp.Threading.Tasks;

namespace Services.GameplayServices
{
	public interface IGameplaySaverService
	{
		UniTask Save();
	}
}