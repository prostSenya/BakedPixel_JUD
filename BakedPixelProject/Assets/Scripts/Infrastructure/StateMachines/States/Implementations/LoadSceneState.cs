using Cysharp.Threading.Tasks;
using Infrastructure.StateMachines.States.Interfaces;
using Services.LoadSceneServices;

namespace Infrastructure.StateMachines.States.Implementations
{
	public class LoadSceneState : IPayloadedState<SceneLoadPayload>
	{
		private readonly ILoadSceneService _loadSceneService;

		public LoadSceneState(ILoadSceneService loadSceneService)
		{
			_loadSceneService = loadSceneService;
		}

		public void Enter(SceneLoadPayload sceneLoadPayload)
		{
			_loadSceneService
				.LoadSceneAsync(sceneLoadPayload)
				.Forget();
		}

		public void Exit()
		{
		}
	}
}