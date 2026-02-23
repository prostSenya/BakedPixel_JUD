using Cysharp.Threading.Tasks;

namespace Services.LoadSceneServices
{
	public interface ILoadSceneService
	{
		public UniTask LoadSceneAsync(SceneLoadPayload sceneLoadPayload);
	}
}