using System;

namespace Wallets.Services
{
	public class WalletService : IWalletService
	{
		public WalletService(int money) => 
			Money = money;

		public event Action<int> MoneyCountChanged;

		public int Money { get; private set; }

		public void AddMoney(int amount)
		{
			if (amount <= 0)
				return;
			
			Money += amount;
			MoneyCountChanged?.Invoke(Money);
		}

		public void DecreaseMoney(int amount)
		{
			if (amount <= 0)
				return;
			
			Money -= amount;
			MoneyCountChanged?.Invoke(Money);
		}
	}
}