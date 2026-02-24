using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayMenu.Inventories
{
	public class InventorySlotView : MonoBehaviour
	{
		[SerializeField] private Image _image;
		[SerializeField] private TextMeshProUGUI _text;
		
		public void SetImage(Sprite sprite) => 
			_image.sprite = sprite;
		
		public void SetTextCount(string text) => 
			_text.text = text;
	}
}