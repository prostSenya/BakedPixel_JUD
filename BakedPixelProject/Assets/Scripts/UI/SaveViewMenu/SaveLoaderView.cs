using UI.BaseUI.Implementations;
using UnityEngine;

namespace UI.SaveViewMenu
{
	public class SaveLoaderView : View, ISaveLoaderView
	{
		public override void Activate()
		{
			enabled = true;
			OnActivate();
		}

		public override void Deactivate()
		{
			enabled = false;
			OnDeactivate();
		}
	}
}
