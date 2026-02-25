using System;
using TMPro;
using UI.BaseUI.Implementations;
using UI.GameplayMenu.Inventories.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayMenu.Inventories.Implementations
{
	public class InventoryView : View, IInventoryView
	{
		[SerializeField] private TextMeshProUGUI _inventoryWeightText;
		[SerializeField] private TextMeshProUGUI _coinsText;
		[SerializeField] private Button _saveButton;

		public event Action SaveButtonClicked;
		
		protected override void OnActivate() => 
			_saveButton.onClick.AddListener(OnSaveButtonClicked);

		protected override void OnDeactivate() => 
			_saveButton.onClick.RemoveListener(OnSaveButtonClicked);

		private void OnSaveButtonClicked() => 
			SaveButtonClicked?.Invoke();

		public void SetInventoryWeightText(string text) => 
			_inventoryWeightText.text = $"Inventory weight = {text} kg";
		
		public void SetCoinsText(string text) => 
			_coinsText.text = $"Coins = {text}";
	}
}
