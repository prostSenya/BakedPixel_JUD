using Infrastructure.Initializers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Installers
{
	public class GameplaySceneInstaller : MonoInstaller
	{
		[SerializeField] private GameplaySceneUIInitializer _gameplaySceneUIInitializer;

		public override void Install(IContainerBuilder builder) => 
			builder.RegisterComponent(_gameplaySceneUIInitializer).AsImplementedInterfaces();
	}
}