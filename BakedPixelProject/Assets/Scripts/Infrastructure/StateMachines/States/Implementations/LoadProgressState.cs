using Infrastructure.StateMachines.States.Interfaces;
using Services.LoadSceneServices;
using Services.SaveLoadServices;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachines.States.Implementations
{
	public class LoadProgressState : IState
	{
		private readonly IGameStateMachine _gameStateMachine;
		private readonly ISaveLoadService _saveLoadService;

		public LoadProgressState(IGameStateMachine gameStateMachine, ISaveLoadService saveLoadService)
		{
			_gameStateMachine = gameStateMachine;
			_saveLoadService = saveLoadService;
		}
		
		public void Enter()
		{
			_saveLoadService.LoadProgress();
			
			SceneLoadPayload sceneLoadPayload = new SceneLoadPayload
			(
				1,
				SceneLoadType.Regular,
				LoadSceneMode.Single,
				() => _gameStateMachine.Enter<GameplayState>()
			);
			
			_gameStateMachine.Enter<LoadSceneState, SceneLoadPayload>(sceneLoadPayload);
		}

		public void Exit()
		{
			
		}
	}
}