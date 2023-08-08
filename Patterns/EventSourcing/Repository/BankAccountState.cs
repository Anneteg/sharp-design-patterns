using EventSourcing.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Repository
{
	/// <summary>
	/// Состояние банковского счёта.
	/// </summary>
	public class BankAccountState
	{
		/// <summary>
		/// Остаток на валютных счетах.
		/// </summary>
		public Dictionary<CurrencyType, decimal> BankAccountBalance;

		/// <summary>
		/// Конструктор.
		/// </summary>
		public BankAccountState()
		{
			BankAccountBalance = new Dictionary<CurrencyType, decimal>
			{
				{CurrencyType.RUB, 0},
				{CurrencyType.EUR, 0},
				{CurrencyType.USD, 0}
			};
		}

	}
}
