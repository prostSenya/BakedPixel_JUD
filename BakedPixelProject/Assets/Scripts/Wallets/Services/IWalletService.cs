namespace Wallets.Services
{
	public interface IWalletService
	{
		int Money { get; }
		void AddMoney(int amount);
	}
}