using Services.PersistentProgressServices;
using UnityEngine;

namespace Wallets.Services
{
	public class WalletSaverService : IWalletSaverService
	{
		private readonly IWalletService _walletService;

		public WalletSaverService(IWalletService walletService) => 
			_walletService = walletService;

		public void ReadProgress(ProjectProgress projectProgress)
		{
		}

		public void WriteProgress(ProjectProgress projectProgress)
		{
			Debug.Log("WalletSaverService: Writing progress...");

			projectProgress.Inventory.Money = _walletService.Money;
		}
	}
}