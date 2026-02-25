using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayMenu.Inventories.Buttons.Views
{
	public class ShootButton : MonoBehaviour
	{
		[SerializeField] private Button _button;

		public event Action Clicked;
		
		private void OnEnable() => 
			_button.onClick.AddListener(OnShootButtonClicked);

		private void OnDisable() => 
			_button.onClick.RemoveListener(OnShootButtonClicked);

		private void OnShootButtonClicked() => 
			Clicked?.Invoke();
	}
}