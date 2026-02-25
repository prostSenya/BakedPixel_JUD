using System;
using UI.BaseUI.Implementations;
using UI.GameplayMenu.Inventories.Buttons.Views.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayMenu.Inventories.Buttons.Views.Implenetations
{
	public class RemoveItemButton : View, IRemoveItemButtonView
	{
		[SerializeField] private Button _button;
		
		public event Action Clicked;
		
		protected override void OnActivate() => 
			_button.onClick.AddListener(OnRemoveItem);

		protected override void OnDeactivate() => 
			_button.onClick.RemoveListener(OnRemoveItem);

		private void OnRemoveItem() => 
			Clicked?.Invoke();
	}
}
