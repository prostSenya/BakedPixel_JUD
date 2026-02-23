using System;
using UnityEngine.SceneManagement;

namespace Services.LoadSceneServices
{
	public struct SceneLoadPayload
	{
		public readonly int SceneID;
		public readonly SceneLoadType LoadType;
		public readonly LoadSceneMode LoadSceneMode;
		public readonly Action OnLoaded;

		public SceneLoadPayload(int sceneID, SceneLoadType loadType, LoadSceneMode loadSceneMode, Action onLoaded)
		{
			SceneID = sceneID;
			LoadType = loadType;
			LoadSceneMode = loadSceneMode;
			OnLoaded = onLoaded;
		}
	}
}