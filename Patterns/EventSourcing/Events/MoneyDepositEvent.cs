using EventSourcing.Enum;
using System;

namespace EventSourcing.Events
{
	/// <summary>
	/// Событие "Внести деньги".
	/// </summary>
	public class MoneyDepositEvent: IEvent
	{
		/// <summary>
		/// Конструктор события.
		/// </summary>
		/// <param name="currencyType">Валюта</param>
		/// <param name="amount">Сумма</param>
		public MoneyDepositEvent(CurrencyType currencyType, decimal amount)
		{
			if (amount <= 0)
			{
				throw new ArgumentException("Вносимая сумма должна быть больше 0.", nameof(amount));
			}

			CurrencyType = currencyType;
			Amount = amount;
		}

		/// <summary>
		/// Валюта.
		/// </summary>
		public CurrencyType CurrencyType { get; set; }

		/// <summary>
		/// Сумма.
		/// </summary>
		public decimal Amount { get; set; }
	}
}
