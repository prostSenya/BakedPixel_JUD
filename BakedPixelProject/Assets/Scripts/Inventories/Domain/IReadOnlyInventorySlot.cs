using System;

namespace Inventories.Domain
{
	public interface IReadOnlyInventorySlot
	{
		int Id { get; }
		int Count { get; }
		ItemKey Key { get; }
		bool IsLocked { get; }
		bool HasItem { get; }
		event Action ItemSetted;
		event Action Cleared;
		event Action ItemRemoved;
	}
}