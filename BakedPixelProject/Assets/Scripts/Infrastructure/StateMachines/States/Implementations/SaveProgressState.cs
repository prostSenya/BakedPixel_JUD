using Infrastructure.StateMachines.States.Interfaces;
using Services.GameplayServices;

namespace Infrastructure.StateMachines.States.Implementations
{
	public class SaveProgressState : IState
	{
		private readonly IGameStateMachine _gameStateMachine;
		private readonly IGameplaySaverService _gameplaySaverService;

		public SaveProgressState(IGameStateMachine gameStateMachine, IGameplaySaverService gameplaySaverService)
		{
			_gameStateMachine = gameStateMachine;
			_gameplaySaverService = gameplaySaverService;
		}
		
		public void Enter()
		{
			_gameplaySaverService.Save();
			_gameStateMachine.Enter<GameplayState>();
		}
	
		public void Exit()
		{
			
		}
	}
}