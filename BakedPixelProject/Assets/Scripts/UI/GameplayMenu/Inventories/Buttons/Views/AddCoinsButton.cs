using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayMenu.Inventories.Buttons.Views
{
	public class AddCoinsButton : MonoBehaviour
	{
		[SerializeField] private Button _button;
		[SerializeField] private int _amount;
		
		public event Action<int> Clicked;
		
		private void OnEnable() => 
			_button.onClick.AddListener(OnAddCoins);

		private void OnDisable() => 
			_button.onClick.RemoveListener(OnAddCoins);

		private void OnAddCoins() => 
			Clicked?.Invoke(_amount);
	}
}