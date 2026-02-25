using System;
using UI.BaseUI.Interfaces;

namespace UI.GameplayMenu.Inventories.Buttons.Views.Interfaces
{
	public interface IAddCoinsButtonView : IView
	{
		event Action<int> Clicked;
	}
}
