using System.Data.Entity;
using UnitOfWork.Model;

namespace UnitOfWork.Context
{
	/// <summary>
	/// Контекст CRM.
	/// </summary>
	public class CrmContext: DbContext
	{
		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="nameOrConnectionString">Имя или строка подключения к БД.</param>
		public CrmContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

		/// <summary>
		/// Контакты.
		/// </summary>
		public DbSet<Contact> Contacts { get; set; }

		/// <summary>
		/// Активности.
		/// </summary>
		public DbSet<Activity> Activities { get; set; }
	}
}
