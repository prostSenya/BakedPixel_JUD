using Services.JsonConvertServices;
using Services.LoadSceneServices;
using Services.PersistentProgressServices;
using Services.ResourceLoaders;
using Services.SaveLoadServices;
using Services.StaticDataServices;
using VContainer;

namespace Infrastructure.DIExtensions
{
	public static partial class RegistererGameStateMachine
	{
		public static IContainerBuilder RegisterServices(this IContainerBuilder containerBuilder)
		{
			containerBuilder.Register<ISaveLoadService, SaveLoadService>(Lifetime.Singleton);
			containerBuilder.Register<ILoadSceneService, LoadSceneService>(Lifetime.Singleton);
			containerBuilder.Register<IResourceLoader, ResourceLoader>(Lifetime.Singleton);
			containerBuilder.Register<IStaticDataService, StaticDataService>(Lifetime.Singleton);
			containerBuilder.Register<IPersistentProgressService, PersistentProgressService>(Lifetime.Singleton);
			containerBuilder.Register<IJsonConvertService, JsonConvertService>(Lifetime.Singleton);
			containerBuilder.Register<IFileProgressStorage, FileProgressStorage>(Lifetime.Singleton);
			
			return containerBuilder;
		}
	}
}