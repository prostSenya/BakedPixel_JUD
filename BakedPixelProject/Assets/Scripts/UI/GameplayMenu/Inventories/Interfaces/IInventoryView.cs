using System;
using UI.BaseUI.Interfaces;

namespace UI.GameplayMenu.Inventories.Interfaces
{
	public interface IInventoryView : IView
	{
		event Action SaveButtonClicked;
		void SetInventoryWeightText(string text);
		void SetCoinsText(string text);
	}
}
