using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayMenu.Inventories.Buttons.Views
{
	public class RemoveItemButton : MonoBehaviour
	{
		[SerializeField] private Button _button;
		
		public event Action Clicked;
		
		private void OnEnable() => 
			_button.onClick.AddListener(OnRemoveItem);

		private void OnDisable() => 
			_button.onClick.RemoveListener(OnRemoveItem);

		private void OnRemoveItem() => 
			Clicked?.Invoke();
	}
}