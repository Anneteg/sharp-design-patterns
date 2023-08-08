using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitOfWork.Model
{
	/// <summary>
	/// Модель объекта "Активность".
	/// </summary>
	[Table("Activity")]
	public class Activity : BaseEntity
	{
		/// <summary>
		/// Заголовок.
		/// </summary>
		[Required]
		public string Title { get; set; }

		/// <summary>
		/// Дата начала.
		/// </summary>
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// Дата завершения.
		/// </summary>
		public DateTime? DueDate { get; set; }

		/// <summary>
		/// Состояние.
		/// </summary>
		public Guid? StatusId { get; set; }

		/// <summary>
		/// Тип.
		/// </summary>
		public Guid? TypeId { get; set; }

		/// <summary>
		/// Категория.
		/// </summary>
		public Guid? CategoryId { get; set; }

		/// <summary>
		/// Ответственный.
		/// </summary>
		public Guid? OwnerId { get; set; }
	}
}
