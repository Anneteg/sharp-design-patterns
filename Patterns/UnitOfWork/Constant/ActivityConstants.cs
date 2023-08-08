using System;

namespace UnitOfWork.Constant
{
	/// <summary>
	/// Класс с константами для активностей.
	/// </summary>
	public class ActivityConstants
	{
		/// <summary>
		/// Тип: Задача.
		/// </summary>
		public static readonly Guid TaskTypeId = new Guid("FBE0ACDC-CFC0-DF11-B00F-001D60E938C6");

		/// <summary>
		/// Категория: Выполнить.
		/// </summary>
		public static readonly Guid ToDoCategoryId = new Guid("F51C4643-58E6-DF11-971B-001D60E938C6");

		/// <summary>
		/// Статус: Не начата.
		/// </summary>
		public static readonly Guid NotStartedStatusId = new Guid("384D4B84-58E6-DF11-971B-001D60E938C6");

		/// <summary>
		/// Статус: В работе.
		/// </summary>
		public static readonly Guid InProgressStatusId = new Guid("394D4B84-58E6-DF11-971B-001D60E938C6");

		/// <summary>
		/// Статус: Завершена.
		/// </summary>
		public static readonly Guid FinishedStatusId = new Guid("4BDBB88F-58E6-DF11-971B-001D60E938C6");

		/// <summary>
		/// Статус: Отменена.
		/// </summary>
		public static readonly Guid CanceledStatusId = new Guid("201CFBA8-58E6-DF11-971B-001D60E938C6");
	}
}
