using Microsoft.VisualStudio.TestTools.UnitTesting;
using Visitor;
using Visitor.Entities;
using Visitor.IntegrationSystems;

namespace Patterns.UnitTest
{
	/// <summary>
	/// Тесты паттерна "Посетитель".
	/// </summary>
	[TestClass]
	public class VisitorTests
	{ 
		/// <summary>
		/// Проверка отправки сущностей в интеграционные системы.
		/// </summary>
		[TestMethod]
		public void SendMessagesToIntegrationSystemsTest()
		{
			var account1 = new Account
			{
				IntegrationId = "7864455",
				Name = "ООО \"Ромашка\"",
				FullName = "ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ \"РОМАШКА\"",
				Inn = "502901575957",
				Ogrn = "1065029121629",
				Email = "romashka@mail.ru"
			};

			var order1 = new Order
			{
				IntegrationId = "4463922",
				Number = "ORD-342",
				Amount = 800500.00M,
				Discount = 6.5M
			};

			var account2 = new Account
			{
				IntegrationId = "66554328",
				Name = "ООО \"Моя оборона\"",
				FullName = "ОБЩЕСТВО С ОГРАНИЧЕННОЙ ОТВЕТСТВЕННОСТЬЮ \"МОЯ ОБОРОНА\"",
				Inn = "502481622175",
				Ogrn = "1185053020240",
				Email = "limonoff@mail.ru"
			};

			var order2 = new Order
			{
				IntegrationId = "77480022",
				Number = "ORD-822",
				Amount = 1500500.00M,
				Discount = 3.5M
			};

			var messageQueue = new MessageQueue();
			messageQueue.Add(account1);
			messageQueue.Add(order1);
			messageQueue.Add(account2);
			messageQueue.Add(order2);

			Assert.IsTrue(messageQueue.Process(new DocumentIntegrationSystem()));
			Assert.IsTrue(messageQueue.Process(new PurchaseIntegrationSystem()));
		}
	}
}