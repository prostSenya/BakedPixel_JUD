using System;
using System.Linq;
using Helpers;
using Inventories;
using Inventories.Factories;
using Inventories.Services;
using Services.RandomServices;
using UI.GameplayMenu.Buttons;
using UI.GameplayMenu.Inventories;
using UnityEngine;
using VContainer;
using VContainer.Unity;
using Wallets.Services;
using Weapons.Services;

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
		private IInventoryService _inventoryService;
		private IWalletService _walletService;
		private IRandomService _randomService;
		private IWeaponService _weaponService;
		
		private InventoryPresenter _inventoryPresenter;

		[Inject]
		private void Construct(
			IInventoryPresenterFactory inventoryPresenterFactory,
			IInventoryService inventoryService,
			IWalletService walletService,
			IRandomService randomService,
			IWeaponService weaponService)
		{
			_weaponService = weaponService;
			_randomService = randomService;
			_walletService = walletService;
			_inventoryService = inventoryService;
			_inventoryPresenterFactory = inventoryPresenterFactory;
		}

		public void Initialize()
		{
			_inventoryPresenter = _inventoryPresenterFactory.Create(_inventoryView, _inventorySlotContainer);
			
			AddBulletsPresenter addBulletsPresenter = new AddBulletsPresenter(_inventoryService, _addBulletsButton, EnumHelper.GetBulletTypes());
			addBulletsPresenter.Show();
			
			AddCoinPresenter addCoinPresenter = new AddCoinPresenter(_addCoinsButton, _walletService);
			addCoinPresenter.Show();
			
			InventoryItemType[] inventoryItemTypes = Enum.GetValues(typeof(InventoryItemType))
				.Cast<InventoryItemType>()
				.Where(type => 
					type != InventoryItemType.Unknown &&
					type != InventoryItemType.Ammo &&
					type != InventoryItemType.None)
				.ToArray();

			AddItemPresenter addItemPresenter = new AddItemPresenter(
				_addItemButton,
				_inventoryService,
				_randomService,
				inventoryItemTypes,
				EnumHelper.GetArmorTypes(),
				EnumHelper.GetWeaponTypes());
			addItemPresenter.Show();
			
			RemoveItemPresenter removeItemPresenter = new RemoveItemPresenter(_removeItemButton, _inventoryService);
			removeItemPresenter.Show();
			
			ShootPresenter shootPresenter = new ShootPresenter(
				_shootButton, 
				_inventoryService,
				_weaponService,
				_randomService,
				EnumHelper.GetBulletTypes());
			shootPresenter.Show();

			_inventoryPresenter.Show();
		}

		private void OnDestroy()
		{
			_inventoryPresenter.Hide();
		}
	}
}