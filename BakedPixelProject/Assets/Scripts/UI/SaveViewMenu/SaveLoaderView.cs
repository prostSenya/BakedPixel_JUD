using UnityEngine;

namespace UI.SaveViewMenu
{
	public class SaveLoaderView : MonoBehaviour
	{
		public void Activate() => 
			enabled = true;

		public void Deactivate() => 
			enabled = false;
	}
}