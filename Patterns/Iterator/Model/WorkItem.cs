namespace Iterator.Model
{
	/// <summary>
	/// Рабочий элемент.
	/// </summary>
	public class WorkItem
	{
		/// <summary>
		/// Номер.
		/// </summary>
		public int Number { get; set; }

		/// <summary>
		/// Тип.
		/// </summary>
		public WorkItemType Type { get; set; }

		/// <summary>
		/// Заголовок.
		/// </summary>
		public string Title { get; set; }

		/// <summary>
		/// Приоритет.
		/// </summary>
		public int Priority { get; set; }

	}
}