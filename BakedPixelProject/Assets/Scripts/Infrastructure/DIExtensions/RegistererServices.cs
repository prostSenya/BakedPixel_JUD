using Services.LoadSceneServices;
using Services.SaveLoadServices;
using VContainer;

namespace Infrastructure.DIExtensions
{
	public static partial class RegistererGameStateMachine
	{
		public static IContainerBuilder RegisterServices(this IContainerBuilder containerBuilder)
		{
			containerBuilder.Register<ISaveLoadService, SaveLoadService>(Lifetime.Singleton);
			containerBuilder.Register<ILoadSceneService, LoadSceneService>(Lifetime.Singleton);
			return containerBuilder;
		}
	}
}