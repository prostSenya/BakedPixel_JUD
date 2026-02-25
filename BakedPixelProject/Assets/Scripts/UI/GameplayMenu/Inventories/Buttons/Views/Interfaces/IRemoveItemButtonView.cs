using System;
using UI.BaseUI.Interfaces;

namespace UI.GameplayMenu.Inventories.Buttons.Views.Interfaces
{
	public interface IRemoveItemButtonView : IView
	{
		event Action Clicked;
	}
}
