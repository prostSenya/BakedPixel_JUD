using Infrastructure.StateMachines.States.Implementations;
using VContainer;

namespace Infrastructure.StateMachines.States.DIExtensions
{
	public static partial class RegistererGameStateMachine
	{
		public static IContainerBuilder RegisterGameStateMachine(this IContainerBuilder builder)
		{
			builder.Register<IGameStateMachine, GameStateMachine>(Lifetime.Singleton);

			builder.Register<BootstrapState>(Lifetime.Singleton)
				.AsImplementedInterfaces()
				.AsSelf();
			
			builder.Register<LoadProgressState>(Lifetime.Singleton)
				.AsImplementedInterfaces()
				.AsSelf();
			
			builder.Register<LoadSceneState>(Lifetime.Singleton)
				.AsImplementedInterfaces()
				.AsSelf();
			
			builder.Register<GameplayState>(Lifetime.Singleton)
				.AsImplementedInterfaces()
				.AsSelf();
			
			return builder;
		}
	}
}