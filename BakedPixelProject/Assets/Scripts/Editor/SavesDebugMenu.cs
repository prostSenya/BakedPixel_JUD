using UnityEditor;
using UnityEngine;

namespace Editor
{
	public class SavesDebugMenu
	{
		[MenuItem("Tools/Saves/Open Persistent Data Path")]
		private static void Open()
		{
			EditorUtility.RevealInFinder(Application.persistentDataPath);
			Debug.Log(Application.persistentDataPath);
		}
	}
}