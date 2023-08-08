using System;
using System.ComponentModel.DataAnnotations;

namespace UnitOfWork.Model
{
	/// <summary>
	/// Модель базовой сущности.
	/// </summary>
	public class BaseEntity
	{
		/// <summary>
		/// Id.
		/// </summary>
		[Required]
		[Key]
		public Guid Id { get; set; }

		/// <summary>
		/// Дата изменения.
		/// </summary>
		public DateTime? ModifiedOn { get; set; }

		/// <summary>
		/// Конструктор.
		/// </summary>
		public BaseEntity()
		{
			ModifiedOn = DateTime.UtcNow;
		}
	}
}
