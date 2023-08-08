using Visitor.Entities;

namespace Visitor
{
	/// <summary>
	/// Интерфейс интеграционной системы.
	/// </summary>
	public interface IIntegrationSystem
	{
		/// <summary>
		/// Название интеграционной системы.
		/// </summary>
		string Name { get; }

		/// <summary>
		/// Обработать сообщение по контрагенту.
		/// </summary>
		/// <param name="account">Контрагент</param>
		string ProcessAccount(Account account);

		/// <summary>
		/// Обработать сообщение по заказу.
		/// </summary>
		/// <param name="order">Заказ</param>
		string ProcessOrder(Order order);

	}
}