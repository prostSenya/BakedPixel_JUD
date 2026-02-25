using System;
using UI.BaseUI.Interfaces;
using UnityEngine;

namespace UI.GameplayMenu.Inventories.Interfaces
{
	public interface IInventorySlotView : IView
	{
		event Action Clicked;
		void SetImage(Sprite sprite);
		void SetTextCount(string text);
	}
}
