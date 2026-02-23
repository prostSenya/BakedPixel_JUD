using Inventories.Factories;
using Services.StateFactories;
using VContainer;

namespace Infrastructure.DIExtensions
{
	public static partial class RegistererGameStateMachine
	{
		public static IContainerBuilder RegisterFactories(this IContainerBuilder builder)
		{
			builder.Register<IStateFactory, StateFactory>(Lifetime.Singleton);
			builder.Register<IInventoryFactory, InventoryFactory>(Lifetime.Singleton);
			
			return builder;
		}
	}
}