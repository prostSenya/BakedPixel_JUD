using System;
using TMPro;
using UI.BaseUI.Implementations;
using UI.GameplayMenu.Inventories.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayMenu.Inventories.Implementations
{
	public class InventorySlotView : View, IInventorySlotView
	{
		[SerializeField] private Image _image;
		[SerializeField] private TextMeshProUGUI _text;
		[SerializeField] private Button _button;
		
		public event Action Clicked;

		protected override void OnActivate() => 
			_button.onClick.AddListener(OnButtonClicked);

		protected override void OnDeactivate() => 
			_button.onClick.RemoveListener(OnButtonClicked);

		private void OnButtonClicked()
		{
			Debug.Log("Clicked");
			Clicked?.Invoke();
		}

		public void SetImage(Sprite sprite) => 
			_image.sprite = sprite;
		
		public void SetTextCount(string text) => 
			_text.text = text;
	}
}
