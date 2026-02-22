using Infrastructure.StateMachines.States.Interfaces;
using UnityEngine;

namespace Infrastructure.StateMachines.States.Implementations
{
	public class LoadProgressState : IState
	{
		private readonly IGameStateMachine _gameStateMachine;

		public LoadProgressState(IGameStateMachine gameStateMachine)
		{
			_gameStateMachine = gameStateMachine;
		}
		
		public void Enter()
		{
			Debug.Log("Update progess");
			_gameStateMachine.Enter<LoadSceneState>();
		}

		public void Exit()
		{
			
		}
	}
}