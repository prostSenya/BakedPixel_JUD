using System;
using UI.BaseUI.Interfaces;

namespace UI.GameplayMenu.Inventories.Buttons.Views.Interfaces
{
	public interface IAddItemButtonView : IView
	{
		event Action Clicked;
	}
}
