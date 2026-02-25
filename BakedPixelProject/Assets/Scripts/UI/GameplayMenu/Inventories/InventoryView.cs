using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayMenu.Inventories
{
	public class InventoryView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _inventoryWeightText;
		[SerializeField] private TextMeshProUGUI _coinsText;
		[SerializeField] private Button _saveButton;

		public event Action SaveButtonClicked;
		
		private void OnEnable() => 
			_saveButton.onClick.AddListener(OnSaveButtonClicked);

		private void OnDisable() => 
			_saveButton.onClick.RemoveListener(OnSaveButtonClicked);

		private void OnSaveButtonClicked() => 
			SaveButtonClicked?.Invoke();

		public void SetInventoryWeightText(string text) => 
			_inventoryWeightText.text = $"Inventory weight = {text} кг";
		
		public void SetCoinsText(string text) => 
			_coinsText.text = $"Coins = {text}";
	}
}