using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayMenu.Inventories
{
	public class InventorySlotView : MonoBehaviour
	{
		[SerializeField] private Image _image;
		[SerializeField] private TextMeshProUGUI _text;
		[SerializeField] private Button _button;
		
		public event Action Clicked;

		private void OnEnable() => 
			_button.onClick.AddListener(OnButtonClicked);

		private void OnDisable() => 
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