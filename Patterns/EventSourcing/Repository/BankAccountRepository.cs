using EventSourcing.Events;
using System;
using System.Collections.Generic;

namespace EventSourcing.Repository
{
	/// <summary>
	/// Репозиторий банковских счётов.
	/// </summary>
	public class BankAccountRepository
	{
		/// <summary>
		/// Банковские счета.
		/// </summary>
		private readonly Dictionary<Guid, IList<IEvent>> _bankAccounts = new Dictionary<Guid, IList<IEvent>>();

		/// <summary>
		/// Создать банковский счёт.
		/// </summary>
		/// <param name="id">Идентификатор счёта</param>
		/// <returns>Банковский счёт</returns>
		public BankAccount Get(Guid id)
		{
			if (id == Guid.Empty)
			{
				throw new ArgumentException(nameof(id));
			}

			var bankAccount = new BankAccount(id);

			if (_bankAccounts.ContainsKey(id))
			{
				foreach (var eventItem in _bankAccounts[id])
				{
					bankAccount.AddEvent(eventItem);
				}
			}

			return bankAccount;
		}

		/// <summary>
		/// Применить операции по счёту.
		/// </summary>
		/// <param name="bankAccount">Банковский счёт</param>
		public void Commit(BankAccount bankAccount)
		{
			if (bankAccount == null)
			{
				throw new ArgumentNullException(nameof(bankAccount));
			}

			_bankAccounts[bankAccount.Id] = bankAccount.GetEvents();
		}

	}
}
