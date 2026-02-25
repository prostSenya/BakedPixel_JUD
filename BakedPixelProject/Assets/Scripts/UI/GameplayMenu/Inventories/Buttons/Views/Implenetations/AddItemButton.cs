using System;
using UI.BaseUI.Implementations;
using UI.GameplayMenu.Inventories.Buttons.Views.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayMenu.Inventories.Buttons.Views.Implenetations
{
	public class AddItemButton : View, IAddItemButtonView
	{
		[SerializeField] private Button _button;
		
		public event Action Clicked;
		
		protected override void OnActivate() => 
			_button.onClick.AddListener(OnAddItem);

		protected override void OnDeactivate() => 
			_button.onClick.RemoveListener(OnAddItem);

		private void OnAddItem() => 
			Clicked?.Invoke();
	}
}
