using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Services.LoadSceneServices
{
	public class LoadSceneService : ILoadSceneService
	{
		public async UniTask LoadSceneAsync(SceneLoadPayload sceneLoadPayload)
		{
			await SceneManager.LoadSceneAsync(sceneLoadPayload.SceneID, sceneLoadPayload.LoadSceneMode);
			sceneLoadPayload.OnLoaded?.Invoke();
		}
	}
}