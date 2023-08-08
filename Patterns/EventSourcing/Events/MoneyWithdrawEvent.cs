using EventSourcing.Enum;
using System;

namespace EventSourcing.Events
{
	/// <summary>
	/// Событие "Снять деньги".
	/// </summary>
	public class MoneyWithdrawEvent: IEvent
	{
		/// <summary>
		/// Конструктор события.
		/// </summary>
		/// <param name="currencyType">Валюта</param>
		/// <param name="amount">Сумма</param>
		public MoneyWithdrawEvent(CurrencyType currencyType, decimal amount)
		{
			if (amount <= 0)
			{
				throw new ArgumentException("Снимаемая сумма должна быть больше 0.", nameof(amount));
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
