using System;

namespace Wallets.Services
{
	public interface IWalletService
	{
		int Money { get; }
		event Action<int> MoneyCountChanged;
		void AddMoney(int amount);
		void DecreaseMoney(int amount);
	}
}