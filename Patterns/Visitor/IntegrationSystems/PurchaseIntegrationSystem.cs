using System;
using Visitor.Entities;

namespace Visitor.IntegrationSystems
{
	/// <summary>
	/// Интеграционная система для работы с покупками.
	/// </summary>
	public class PurchaseIntegrationSystem : IIntegrationSystem
	{
		/// <summary>
		/// Название интеграционной системы.
		/// </summary>
		public string Name { get; } = "Система для работы с покупками";

		/// <summary>
		/// Обработать сообщение по контрагенту.
		/// </summary>
		/// <param name="account">Контрагент</param>
		public string ProcessAccount(Account account)
		{
			if (account == null)
			{
				throw new ArgumentNullException(nameof(account));
			}

			var message = $"Интеграционный идентификатор: {account.IntegrationId}\n" +
			              $"Наименование: {account.Name}\n" +
			              $"Контактный e-mail: {account.Email}\n";

			return message;
		}

		/// <summary>
		/// Обработать сообщение по заказу.
		/// </summary>
		/// <param name="order">Заказ</param>
		public string ProcessOrder(Order order)
		{
			if (order == null)
			{
				throw new ArgumentNullException(nameof(order));
			}

			var message = $"Интеграционный идентификатор: {order.IntegrationId}\n" +
			              $"Номер заказа: {order.Number}\n" +
			              $"Сумма заказа: {order.Amount}\n" +
			              $"Процент скидки: {order.Discount}\n";

			return message;
		}
	}
}