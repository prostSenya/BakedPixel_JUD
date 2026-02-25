using System;
using UI.BaseUI.Interfaces;

namespace UI.GameplayMenu.Inventories.Buttons.Views.Interfaces
{
	public interface IShootButtonView : IView
	{
		event Action Clicked;
	}
}
