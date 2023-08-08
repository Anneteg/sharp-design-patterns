using UnitOfWork.Context;
using UnitOfWork.Model;

namespace UnitOfWork.Repository
{
	/// <summary>
	///  Репозиторий по объекту Контакт.
	/// </summary>
	public class ContactRepository : BaseRepository<Contact>
	{
		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="context">Контекст CRM.</param>
		public ContactRepository(CrmContext context) : base(context)
		{
		}
	}
}
