using Infrastructure.StateMachines;
using Infrastructure.StateMachines.States.Implementations;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Initializers
{
	public class ProjectInitializer : MonoBehaviour, IInitializable
	{
		private IGameStateMachine _gameStateMachine;

		[Inject]
		private void Construct(IGameStateMachine gameStateMachine) => 
			_gameStateMachine = gameStateMachine;

		public void Initialize() => 
			_gameStateMachine.Enter<BootstrapState>();
	}
}