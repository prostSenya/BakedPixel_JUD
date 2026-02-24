using System.Collections.Generic;

namespace Services.RandomServices
{
	public interface IRandomService
	{
		T GetRandomElement<T>(T[] array);
		T GetRandomElement<T>(IReadOnlyList<T> array);
	}
}