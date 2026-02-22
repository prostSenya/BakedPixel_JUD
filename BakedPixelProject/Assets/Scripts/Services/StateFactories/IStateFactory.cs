using Infrastructure.StateMachines.States.Interfaces;

namespace Services.StateFactories
{
	public interface IStateFactory
	{
		T GetState <T>() where T : IExitableState;

	}
}