using Infrastructure.DIExtensions;
using Infrastructure.Initializers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Installers
{
	public class ProjectInstaller : MonoInstaller
	{
		[SerializeField] private ProjectInitializer _projectInitializer;
		
		public override void Install(IContainerBuilder builder)
		{
			builder
				.RegisterGameStateMachine()
				.RegisterFactories()
				.RegisterServices()
				.RegisterComponent(_projectInitializer).AsImplementedInterfaces()
				;
		}
	}
}