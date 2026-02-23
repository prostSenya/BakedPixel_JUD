using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayMenu.Buttons
{
	public class AddItemButton : MonoBehaviour
	{
		[SerializeField] private Button _button;
		
		public event Action Clicked;
		
		private void OnEnable() => 
			_button.onClick.AddListener(OnAddItem);

		private void OnDisable() => 
			_button.onClick.RemoveListener(OnAddItem);

		private void OnAddItem() => 
			Clicked?.Invoke();
	}
}