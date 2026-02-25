using Cysharp.Threading.Tasks;
using Infrastructure.StateMachines.States.Interfaces;
using Services.GameplayServices;
using UnityEngine;

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
		
		public void Enter() => 
			SaveData().Forget();

		public void Exit()
		{ }

		private async UniTask SaveData()
		{
			await _gameplaySaverService.Save();
			_gameStateMachine.Enter<GameplayState>();
		}
	}
}