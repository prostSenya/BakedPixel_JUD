using TMPro;
using UnityEngine;

namespace UI.GameplayMenu.Inventories
{
	public class InventoryView : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI _inventoryWeightText;
		[SerializeField] private TextMeshProUGUI _coinsText;
		
		public void SetInventoryWeightText(string text) => 
			_inventoryWeightText.text = $"Inventory weight = {text} кг";
		
		public void SetCoinsText(string text) => 
			_coinsText.text = $"Coins = {text}";
	}
}