using Infrastructure.StateMachines.States.Interfaces;

namespace Infrastructure.StateMachines.States.Implementations
{
	public class BootstrapState : IState
	{
		private readonly IGameStateMachine _gameStateMachine;

		public BootstrapState(IGameStateMachine gameStateMachine) => 
			_gameStateMachine = gameStateMachine;

		public void Enter()
		{
			_gameStateMachine.Enter<LoadProgressState>();
		}

		public void Exit()
		{
		}
	}
}