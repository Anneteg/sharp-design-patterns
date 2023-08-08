using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UnitOfWork.Model
{
	/// <summary>
	/// Модель объекта "Контакт".
	/// </summary>
	[Table("Contact")]
	public class Contact : BaseEntity
	{
		/// <summary>
		/// ФИО.
		/// </summary>
		[Required]
		public string Name { get; set; }
	}
}
