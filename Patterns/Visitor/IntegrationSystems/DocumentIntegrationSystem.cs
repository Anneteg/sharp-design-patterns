using System;
using Visitor.Entities;

namespace Visitor.IntegrationSystems
{
	/// <summary>
	/// Интеграционная система для работы с документами.
	/// </summary>
	public class DocumentIntegrationSystem : IIntegrationSystem
	{
		/// <summary>
		/// Название интеграционной системы.
		/// </summary>
		public string Name { get; } = "Система для работы с документами";

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
			              $"Полное наименование: {account.FullName}\n" +
			              $"ИНН: {account.Inn}\n" +
			              $"ОГРН: {account.Ogrn}\n";

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
			              $"Номер заказа: {order.Number}\n";

			return message;
		}
	}
}