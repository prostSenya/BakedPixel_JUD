using Infrastructure.StateMachines.States.Interfaces;
using Services.LoadSceneServices;
using Services.SaveLoadServices;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachines.States.Implementations
{
	public class SaveProgressState : IState
	{
		private readonly IGameStateMachine _gameStateMachine;
		private readonly ISaveLoadService _saveLoadService;
	
		public SaveProgressState(IGameStateMachine gameStateMachine, ISaveLoadService saveLoadService)
		{
			_gameStateMachine = gameStateMachine;
			_saveLoadService = saveLoadService;
		}
		
		public void Enter()
		{
			_saveLoadService.SaveProgress();
		}
	
		public void Exit()
		{
			
		}
	}
}