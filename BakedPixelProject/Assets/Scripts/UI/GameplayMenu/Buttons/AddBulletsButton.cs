using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayMenu.Buttons
{
	public class AddBulletsButton : MonoBehaviour
	{
		[SerializeField] private Button _button;
		
		public event Action Clicked;
		
		private void OnEnable() => 
			_button.onClick.AddListener(OnAddBullets);

		private void OnDisable() => 
			_button.onClick.RemoveListener(OnAddBullets);

		private void OnAddBullets() => 
			Clicked?.Invoke();
	}
}