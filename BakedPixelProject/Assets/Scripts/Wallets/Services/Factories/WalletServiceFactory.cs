using Services.PersistentProgressServices;

namespace Wallets.Services
{
	public class WalletServiceFactory : IWalletServiceFactory
	{
		private readonly IPersistentProgressService _progressService;

		public WalletServiceFactory(IPersistentProgressService progressService) => 
			_progressService = progressService;

		public IWalletService Create() => 
			new WalletService(_progressService.ProjectProgress.Inventory?.Money ?? 0);
	}
}