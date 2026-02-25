using System;
using UI.BaseUI.Implementations;
using UI.GameplayMenu.Inventories.Buttons.Views.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UI.GameplayMenu.Inventories.Buttons.Views.Implenetations
{
	public class AddBulletsButton : View, IAddBulletsButtonView
	{
		[SerializeField] private Button _button;
		[SerializeField] private int _bulletsToAdd;
		public event Action<int> Clicked;
		
		protected override void OnActivate() => 
			_button.onClick.AddListener(OnAddBullets);

		protected override void OnDeactivate() => 
			_button.onClick.RemoveListener(OnAddBullets);

		private void OnAddBullets() => 
			Clicked?.Invoke(_bulletsToAdd);
	}
}
