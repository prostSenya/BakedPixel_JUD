using Infrastructure.StateMachines.States.Interfaces;
using Services.StaticDataServices;

namespace Infrastructure.StateMachines.States.Implementations
{
	public class BootstrapState : IState
	{
		private readonly IGameStateMachine _gameStateMachine;
		private readonly IStaticDataService _staticDataService;

		public BootstrapState(IGameStateMachine gameStateMachine, IStaticDataService staticDataService)
		{
			_gameStateMachine = gameStateMachine;
			_staticDataService = staticDataService;
		}

		public void Enter()
		{
			_staticDataService.LoadAll();
			_gameStateMachine.Enter<LoadProgressState>();
		}

		public void Exit()
		{
		}
	}
}