namespace Wallets.Services
{
	public class WalletService : IWalletService
	{
		public int Money { get; private set; }
		public void AddMoney(int amount)
		{
			if (amount <= 0)
				return;
			
			Money += amount;
		}

		public void DecreaseMoney(int amount)
		{
			if (amount <= 0)
				return;
			
			Money -= amount;
		}
	}
}