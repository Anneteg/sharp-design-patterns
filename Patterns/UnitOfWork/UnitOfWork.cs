using System;
using System.Data.Entity;
using UnitOfWork.Context;
using UnitOfWork.Repository;

namespace UnitOfWork
{
	/// <summary>
	/// Класс реализующий паттерн UnitOfWork.
	/// </summary>
	public class UnitOfWork : IDisposable
	{
		/// <summary>
		/// Признак того, что управляемые ресурсы освобождены.
		/// </summary>
		private bool disposed = false;

		/// <summary>
		/// Контекст CRM.
		/// </summary>
		private CrmContext _context;

		/// <summary>
		/// Транзакция.
		/// </summary>
		private DbContextTransaction _transaction;

		/// <summary>
		/// Репозиторий контакта.
		/// </summary>
		private ContactRepository _contactRepository;

		/// <summary>
		/// Репозиторий активности.
		/// </summary>
		private ActivityRepository _activityRepository;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="crmContext">Контекст.</param>
		public UnitOfWork(CrmContext crmContext)
		{
			_context = crmContext ?? throw new ArgumentNullException(nameof(crmContext));
		}

		/// <summary>
		/// Репозиторий контакта.
		/// </summary>
		public ContactRepository ContactRepository
		{
			get
			{
				if (_contactRepository == null)
				{
					_contactRepository = new ContactRepository(_context);
				}
				return _contactRepository;
			}
		}

		/// <summary>
		/// Репозиторий активности.
		/// </summary>
		public ActivityRepository ActivityRepository
		{
			get
			{
				if (_activityRepository == null)
				{
					_activityRepository = new ActivityRepository(_context);
				}
				return _activityRepository;
			}
		}

		/// <summary>
		/// Создать транзакцию.
		/// </summary>
		public void CreateTransaction()
		{
			_transaction = _context.Database.BeginTransaction();
		}

		/// <summary>
		/// Сохранить изменения в БД.
		/// </summary>
		public void Commit()
		{
			_context.SaveChanges();
			_transaction.Commit();
		}

		/// <summary>
		/// Откатить изменения, сделанные в транзакции.
		/// </summary>
		public void Rollback()
		{
			_transaction.Rollback();
			_transaction.Dispose();
		}

		/// <summary>
		/// Реализация логики освобождения ресурсов из памяти.
		/// </summary>
		/// <param name="disposing">Признак вызова публичного метода Dispose.</param>
		public virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}

				disposed = true;
			}
		}

		/// <summary>
		/// Реализация интерфейса IDisposable.
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
