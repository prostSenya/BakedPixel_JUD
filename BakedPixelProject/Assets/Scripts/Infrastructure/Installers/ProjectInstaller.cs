using VContainer;

namespace Infrastructure.Installers
{
	public class ProjectInstaller : MonoInstaller
	{
		public override void Install(IContainerBuilder builder)
		{
			 // builder
				// .RegisterGlobalServices()
				// .RegisterGlobalFactories()
				// .RegisterGlobalUIStates()
				// .RegisterGlobalUserInterface()
				// .RegisterGlobalBattleStateMachine()
				// ;
			 //
			 // builder.RegisterEntryPoint<GameBootstrapper>();
		}
	}
}