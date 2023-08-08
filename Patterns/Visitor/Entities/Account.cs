using System;
using System.Diagnostics;

namespace Visitor.Entities
{
	/// <summary>
	/// Контрагент.
	/// </summary>
	public class Account : IEntity
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
		/// Наименование.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Полное наименование.
		/// </summary>
		public string FullName { get; set; }

		/// <summary>
		/// ИНН.
		/// </summary>
		public string Inn { get; set; }

		/// <summary>
		/// ОГРН.
		/// </summary>
		public string Ogrn { get; set; }

		/// <summary>
		/// Контактный e-mail.
		/// </summary>
		public string Email { get; set; }

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

			Trace.WriteLine($"Отправка контрагента в [{integrationSystem.Name}]");
			Trace.WriteLine(integrationSystem.ProcessAccount(this));
		}
	}
}