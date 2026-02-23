using UnityEngine;

namespace Services.ResourceLoaders
{
	public interface IResourceLoader
	{
		T Load<T>(string path) where T : Object;
		public T[] LoadAll<T>(string path) where T : Object;
	}
}