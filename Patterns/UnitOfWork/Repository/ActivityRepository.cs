using UnitOfWork.Context;
using UnitOfWork.Model;

namespace UnitOfWork.Repository
{
	/// <summary>
	/// Репозиторий по объекту Активность.
	/// </summary>
	public class ActivityRepository : BaseRepository<Activity>
	{
		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="context">Контекст CRM.</param>
		public ActivityRepository(CrmContext context) : base(context)
		{
		}
	}
}
