using System;
using System.Diagnostics;

namespace Visitor.Entities
{
	/// <summary>
	/// Заказ.
	/// </summary>
	public class Order: IEntity
	{
		/// <summary>
		/// Id.
		/// </summary>
		public Guid Id;

		/// <summary>
		/// Интеграционный идентификатор.
		/// </summary>
		public string IntegrationId { get; set; }

		/// <summary>
		/// Номер.
		/// </summary>
		public string Number { get; set; }

		/// <summary>
		/// Сумма с НДС.
		/// </summary>
		public decimal Amount { get; set; }

		/// <summary>
		/// Процент скидки.
		/// </summary>
		public decimal Discount { get; set; }

		/// <summary>
		/// Отправить сообщение в интеграционную систему.
		/// </summary>
		/// <param name="integrationSystem">Интеграционная система</param>
		public void Process(IIntegrationSystem integrationSystem)
		{
			if (integrationSystem == null)
			{
				throw new ArgumentNullException(nameof(integrationSystem));
			}

			Trace.WriteLine($"Отправка заказа в [{integrationSystem.Name}]");
			Trace.WriteLine(integrationSystem.ProcessOrder(this));
		}
	}
}