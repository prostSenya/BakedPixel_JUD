using System;
using UI.BaseUI.Interfaces;

namespace UI.GameplayMenu.Inventories.Buttons.Views.Interfaces
{
	public interface IAddBulletsButtonView : IView
	{
		event Action<int> Clicked;
	}
}
