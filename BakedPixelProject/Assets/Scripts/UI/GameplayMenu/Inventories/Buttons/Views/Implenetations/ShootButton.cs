using System;
using UI.BaseUI.Implementations;
using UI.GameplayMenu.Inventories.Buttons.Views.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayMenu.Inventories.Buttons.Views.Implenetations
{
	public class ShootButton : View, IShootButtonView
	{
		[SerializeField] private Button _button;

		public event Action Clicked;
		
		protected override void OnActivate() => 
			_button.onClick.AddListener(OnShootButtonClicked);

		protected override void OnDeactivate() => 
			_button.onClick.RemoveListener(OnShootButtonClicked);

		private void OnShootButtonClicked() => 
			Clicked?.Invoke();
	}
}
