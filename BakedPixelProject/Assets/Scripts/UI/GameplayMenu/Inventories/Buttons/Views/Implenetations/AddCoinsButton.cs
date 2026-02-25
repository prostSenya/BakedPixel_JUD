using System;
using UI.BaseUI.Implementations;
using UI.GameplayMenu.Inventories.Buttons.Views.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayMenu.Inventories.Buttons.Views.Implenetations
{
	public class AddCoinsButton : View, IAddCoinsButtonView
	{
		[SerializeField] private Button _button;
		[SerializeField] private int _amount;
		
		public event Action<int> Clicked;
		
		protected override void OnActivate() => 
			_button.onClick.AddListener(OnAddCoins);

		protected override void OnDeactivate() => 
			_button.onClick.RemoveListener(OnAddCoins);

		private void OnAddCoins() => 
			Clicked?.Invoke(_amount);
	}
}
