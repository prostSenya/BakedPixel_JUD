using System.Collections.Generic;
using UnityEngine;

namespace Services.RandomServices
{
	public class RandomService : IRandomService
	{
		public T GetRandomElement<T>(T[] array) => 
			array[Random.Range(0, array.Length)];
		
		public T GetRandomElement<T>(IReadOnlyList<T> collection) => 
			collection[Random.Range(0, collection.Count)];
	}
}