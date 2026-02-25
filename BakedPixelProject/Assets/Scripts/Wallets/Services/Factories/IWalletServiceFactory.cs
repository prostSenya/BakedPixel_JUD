namespace Wallets.Services
{
	public interface IWalletServiceFactory
	{
		public IWalletService Create();
	}
}