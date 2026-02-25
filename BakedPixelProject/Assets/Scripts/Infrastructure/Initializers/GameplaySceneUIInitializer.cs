using System.Collections.Generic;
using UI.BaseUI.Interfaces;
using UI.GameplayMenu.Factories.Interfaces;
using UI.GameplayMenu.Inventories;
using UI.GameplayMenu.Inventories.Buttons.Views;
using UI.GameplayMenu.Inventories.Buttons.Views.Implenetations;
using UI.GameplayMenu.Inventories.Implementations;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace Infrastructure.Initializers
{
	public class GameplaySceneUIInitializer : MonoBehaviour, IInitializable
	{
		[SerializeField] private InventoryView _inventoryView;
		[SerializeField] private Transform _inventorySlotContainer;
		[SerializeField] private AddBulletsButton _addBulletsButton;
		[SerializeField] private AddCoinsButton _addCoinsButton;
		[SerializeField] private AddItemButton _addItemButton;
		[SerializeField] private RemoveItemButton _removeItemButton;
		[SerializeField] private ShootButton _shootButton;

		private IInventoryPresenterFactory _inventoryPresenterFactory;
		private IAddBulletsButtonPresenterFactory _addBulletsButtonPresenterFactory;
		private IAddCoinsButtonPresenterFactory _addCoinsButtonPresenterFactory;
		private IAddItemButtonPresenterFactory _addItemButtonPresenterFactory;
		private IRemoveItemButtonPresenterFactory _removeItemButtonPresenterFactory;
		private IShootButtonPresenterFactory _shootButtonPresenterFactory;

		private readonly List<IPresenter> _presenters = new();

		[Inject]
		private void Construct(
			IInventoryPresenterFactory inventoryPresenterFactory,
			IAddBulletsButtonPresenterFactory addBulletsButtonPresenterFactory,
			IAddCoinsButtonPresenterFactory addCoinsButtonPresenterFactory,
			IAddItemButtonPresenterFactory addItemButtonPresenterFactory,
			IRemoveItemButtonPresenterFactory removeItemButtonPresenterFactory,
			IShootButtonPresenterFactory shootButtonPresenterFactory)
		{
			_inventoryPresenterFactory = inventoryPresenterFactory;
			_addBulletsButtonPresenterFactory = addBulletsButtonPresenterFactory;
			_addCoinsButtonPresenterFactory = addCoinsButtonPresenterFactory;
			_addItemButtonPresenterFactory = addItemButtonPresenterFactory;
			_removeItemButtonPresenterFactory = removeItemButtonPresenterFactory;
			_shootButtonPresenterFactory = shootButtonPresenterFactory;
		}

		public void Initialize()
		{
			_presenters.Clear();
			_presenters.Add(_inventoryPresenterFactory.Create(_inventoryView, _inventorySlotContainer));
			_presenters.Add(_addBulletsButtonPresenterFactory.Create(_addBulletsButton));
			_presenters.Add(_addCoinsButtonPresenterFactory.Create(_addCoinsButton));
			_presenters.Add(_addItemButtonPresenterFactory.Create(_addItemButton));
			_presenters.Add(_removeItemButtonPresenterFactory.Create(_removeItemButton));
			_presenters.Add(_shootButtonPresenterFactory.Create(_shootButton));

			foreach (IPresenter presenter in _presenters)
				presenter.Activate();
		}

		private void OnDestroy()
		{
			foreach (IPresenter presenter in _presenters)
				presenter.Deactivate();
		}
	}
}
