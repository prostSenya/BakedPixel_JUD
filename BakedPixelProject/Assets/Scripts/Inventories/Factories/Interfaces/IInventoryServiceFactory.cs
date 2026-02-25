using Inventories.Services;

namespace Inventories.Factories.Interfaces
{
	public interface IInventoryServiceFactory
	{
		IInventoryService Create();
	}
}