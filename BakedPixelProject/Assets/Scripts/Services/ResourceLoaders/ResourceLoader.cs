using UnityEngine;

namespace Services.ResourceLoaders
{
	public class ResourceLoader : IResourceLoader
	{
		public T Load<T>(string path) where T : Object => 
			Resources.Load<T>(path);

		public T[] LoadAll<T>(string path) where T : Object => 
			Resources.LoadAll<T>(path);
	}
}