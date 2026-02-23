using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayMenu.Inventories
{
	public class InventorySlotView : MonoBehaviour
	{
		[SerializeField] private Image _image;

		public void Initialize(Sprite sprite)
		{
			_image.sprite = sprite;
		}
	}
}