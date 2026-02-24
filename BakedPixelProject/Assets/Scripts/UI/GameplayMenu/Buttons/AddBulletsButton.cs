using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayMenu.Buttons
{
	public class AddBulletsButton : MonoBehaviour
	{
		[SerializeField] private Button _button;
		[SerializeField] private int _bulletsToAdd;
		public event Action<int> Clicked;
		
		private void OnEnable() => 
			_button.onClick.AddListener(OnAddBullets);

		private void OnDisable() => 
			_button.onClick.RemoveListener(OnAddBullets);

		private void OnAddBullets() => 
			Clicked?.Invoke(_bulletsToAdd);
	}
}