using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UnitOfWork.Context;
using UnitOfWork.Model;

namespace UnitOfWork.Repository
{
	/// <summary>
	/// Базовый репозиторий.
	/// </summary>
	/// <typeparam name="TEntity">Сущность.</typeparam>
	public class BaseRepository<TEntity> where TEntity : BaseEntity
	{
		/// <summary>
		/// Контекст CRM.
		/// </summary>
		protected CrmContext Context;

		/// <summary>
		/// Коллекция сущности в контексте.
		/// </summary>
		private DbSet<TEntity> _dbSet;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="context">Контекст CRM.</param>
		public BaseRepository(CrmContext context)
		{
			if (context == null)
			{
				throw new ArgumentNullException(nameof(context));
			}

			Context = context;

			_dbSet = context.Set<TEntity>();
		}

		/// <summary>
		/// Получить всю коллекцию сущностей.
		/// </summary>
		/// <returns>Коллекция сущностей.</returns>
		public virtual IEnumerable<TEntity> GetAll()
		{
			return _dbSet?.ToList();
		}

		/// <summary>
		/// Получить сущность по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		/// <returns>Сущность.</returns>
		public virtual TEntity GetById(Guid id)
		{
			if (id == Guid.Empty)
			{
				throw new ArgumentNullException(nameof(id));
			}

			return _dbSet.Find(id);
		}

		/// <summary>
		/// Добавить сущность.
		/// </summary>
		/// <param name="entity">Сущность для добавления.</param>
		public virtual void Insert(TEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			_dbSet.Add(entity);
		}

		/// <summary>
		/// Обновить сущность.
		/// </summary>
		/// <param name="entity">Сущность для обновления.</param>
		public virtual void Update(TEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			_dbSet.Attach(entity);
			Context.Entry(entity).State = EntityState.Modified;
		}

		/// <summary>
		/// Удалить сущность по идентификатору.
		/// </summary>
		/// <param name="id">Идентификатор.</param>
		public virtual void Delete(Guid id)
		{
			if (id == Guid.Empty)
			{
				throw new ArgumentNullException(nameof(id));
			}

			var entity = _dbSet.Find(id);
			if (entity != null)
			{
				_dbSet.Remove(entity);
			}
		}
	}
}
