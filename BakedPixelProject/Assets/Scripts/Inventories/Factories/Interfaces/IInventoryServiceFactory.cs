using Inventories.Services;

namespace Inventories.Factories
{
	public interface IInventoryServiceFactory
	{
		IInventoryService Create();
	}
}