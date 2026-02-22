using UnityEngine;

namespace Infrastructure.Scopes
{
	public class SceneScope : CustomScope
	{
		private void OnValidate()
		{
			if (autoRun == false) 
				Debug.LogError("scene scope auto run is false");

			autoRun = true;
		}
	}
}