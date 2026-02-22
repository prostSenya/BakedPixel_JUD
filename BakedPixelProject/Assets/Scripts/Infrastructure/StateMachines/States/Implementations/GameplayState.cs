using Infrastructure.StateMachines.States.Interfaces;
using UnityEngine;

namespace Infrastructure.StateMachines.States.Implementations
{
	public class GameplayState : IState
	{
		public void Enter()
		{
			Debug.Log("Entering GameplayState");
		}

		public void Exit()
		{
			
		}
	}
}