using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayMenu.Buttons
{
	public class AddCoinsButton : MonoBehaviour
	{
		[SerializeField] private Button _button;
		
		public event Action Clicked;
		
		private void OnEnable() => 
			_button.onClick.AddListener(OnAddCoins);

		private void OnDisable() => 
			_button.onClick.RemoveListener(OnAddCoins);

		private void OnAddCoins() => 
			Clicked?.Invoke();
	}
}