using Infrastructure.StateMachines.States.Interfaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.StateMachines.States.Implementations
{
	public class LoadSceneState : IState
	{
		private const string SceneName = "GameplayScene";
		private readonly IGameStateMachine _gameStateMachine;

		public LoadSceneState(IGameStateMachine gameStateMachine)
		{
			_gameStateMachine = gameStateMachine;
		}
		
		public void Enter()
		{
			Debug.Log("Enter LoadSceneState");
			Debug.LogWarning("Scene loading " + SceneName);
			SceneManager.LoadScene(SceneName);
			Debug.LogWarning("Scene loaded " + SceneName);
			
			_gameStateMachine.Enter<GameplayState>();
		}

		public void Exit()
		{
			
		}
	}
}