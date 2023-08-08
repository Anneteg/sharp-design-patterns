using EventSourcing.Enum;
using EventSourcing.Events;
using EventSourcing.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Patterns.UnitTest
{
	/// <summary>
	/// Тест паттерна "Event Sourcing".
	/// </summary>
	[TestClass]
	public class EventSourcingTests
	{
		/// <summary>
		/// Тест паттерна "Event Sourcing".
		/// </summary>
		[TestMethod]
		public void EventSourcingTest()
		{
			var repository = new BankAccountRepository();

			var bankAccountId = Guid.NewGuid();
			var bankAccount = repository.Get(bankAccountId);

			bankAccount.AddEvent(new MoneyDepositEvent(CurrencyType.EUR, 50));
			bankAccount.AddEvent(new MoneyDepositEvent(CurrencyType.RUB, 5000));
			bankAccount.AddEvent(new MoneyWithdrawEvent(CurrencyType.EUR, 20));
			bankAccount.AddEvent(new MoneyDepositEvent(CurrencyType.RUB, 25000));
			bankAccount.AddEvent(new MoneyDepositEvent(CurrencyType.USD, 500));
			bankAccount.AddEvent(new MoneyWithdrawEvent(CurrencyType.RUB, 999));

			repository.Commit(bankAccount);
						
			bankAccount = repository.Get(bankAccountId); // Проверяем, что наш счёт доступен по тому же Id;
			Assert.AreEqual(6, bankAccount.GetEvents().Count);

			// Проверяем текущее состояние счёта.
			var currentState = bankAccount.GetCurrentState(); 
			Assert.AreEqual(currentState.BankAccountBalance[CurrencyType.RUB], 29001);
			Assert.AreEqual(currentState.BankAccountBalance[CurrencyType.EUR], 30);
			Assert.AreEqual(currentState.BankAccountBalance[CurrencyType.USD], 500);

			// Проверяем состояние счёта на момент события c индексом 2.
			var historicalState = bankAccount.GetStateByEventIndex(2);
			Assert.AreEqual(historicalState.BankAccountBalance[CurrencyType.RUB], 5000);
			Assert.AreEqual(historicalState.BankAccountBalance[CurrencyType.EUR], 30);
			Assert.AreEqual(historicalState.BankAccountBalance[CurrencyType.USD], 0);

		}
	}
}
