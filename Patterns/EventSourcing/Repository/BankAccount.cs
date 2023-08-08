using EventSourcing.Enum;
using EventSourcing.Events;
using System;
using System.Collections.Generic;

namespace EventSourcing.Repository
{
	/// <summary>
	/// Банковский счёт.
	/// </summary>
	public class BankAccount
	{
		/// <summary>
		/// Набор событий.
		/// </summary>
		private readonly List<IEvent> _events = new List<IEvent>();

		/// <summary>
		/// Текущее состояние.
		/// </summary>
		private readonly BankAccountState _state = new BankAccountState();

		/// <summary>
		/// Идентификатор банковского счёта.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="id"> Id. </param>
		public BankAccount(Guid id)
		{
			if (id == Guid.Empty)
			{
				throw new ArgumentException(nameof(id));
			}

			Id = id;
		}

		/// <summary>
		/// Получить события.
		/// </summary>
		/// <returns> События. </returns>
		public List<IEvent> GetEvents()
		{
			return _events;
		}

		/// <summary>
		/// Получить текущее состояние счёта.
		/// </summary>
		/// <returns>Текущее состояние счёта</returns>
		public BankAccountState GetCurrentState()
		{
			return new BankAccountState
			{
				BankAccountBalance = new Dictionary<CurrencyType, decimal>(_state.BankAccountBalance)
			};
		}

		/// <summary>
		/// Получить состояние счёта по индексу события.
		/// </summary>
		/// <param name="eventIndex">Индекс событи</param>
		/// <returns></returns>
		public BankAccountState GetStateByEventIndex(int eventIndex)
		{
			var result = new BankAccountState();

			for (var currentIndex = 0; currentIndex < _events.Count; currentIndex++)
			{
				if (currentIndex > eventIndex)
				{
					return result;
				}
				OnEvent(result, _events[currentIndex]);
			}

			return result;
		}

		/// <summary>
		/// Добавить событие.
		/// </summary>
		/// <param name="eventItem"> Событие. </param>
		public void AddEvent(IEvent eventItem)
		{
			if (eventItem == null)
			{
				throw new ArgumentNullException(nameof(eventItem));
			}

			OnEvent(_state, eventItem);
			_events.Add(eventItem);
		}

		/// <summary>
		/// Применить событие.
		/// </summary>
		/// <param name="state"> Состояние счёта. </param>
		/// <param name="eventItem"> Событие. </param>
		private void OnEvent(BankAccountState state, IEvent eventItem)
		{
			switch (eventItem)
			{
				case MoneyDepositEvent deposit:
					On(state, deposit);
					break;
				case MoneyWithdrawEvent withdraw:
					On(state, withdraw);
					break;
				default:
					throw new InvalidOperationException($"Undefined event {eventItem.GetType()}");
			}
		}

		/// <summary>
		/// Применить событие по внесению денег на счёт.
		/// </summary>
		/// <param name="state"> Состояние счёта. </param>
		/// <param name="deposit"> Событие по внесению денег на счёт. </param>
		private void On(BankAccountState state, MoneyDepositEvent deposit)
		{
			var amount = deposit.Amount;
			state.BankAccountBalance[deposit.CurrencyType] += amount;
		}

		/// <summary>
		/// Применить событие по снятию денег со счёта.
		/// </summary>
		/// <param name="state"> Состояние счёта. </param>
		/// <param name="withdraw"> Событие по снятию денег со счёта. </param>
		private void On(BankAccountState state, MoneyWithdrawEvent withdraw)
		{
			var amount = withdraw.Amount;
			if (state.BankAccountBalance[withdraw.CurrencyType] < amount)
			{
				throw new Exception(
					$"Недостаточно средств для выполнения операции по счету {withdraw.CurrencyType}. Доступно: {_state.BankAccountBalance[withdraw.CurrencyType]} единиц.");
			}

			state.BankAccountBalance[withdraw.CurrencyType] -= amount;
		}
	}
}
