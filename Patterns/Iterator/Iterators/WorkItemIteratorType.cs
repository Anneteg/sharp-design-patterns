namespace Iterator.Iterators
{
	/// <summary>
	/// Тип итератора рабочих элементов.
	/// </summary>
	public enum WorkItemIteratorType
	{
		/// <summary>
		/// По приоритету.
		/// </summary>
		Priority,

		/// <summary>
		/// По типу - сначала все баги, потом все задачи.
		/// </summary>
		Type,

		/// <summary>
		/// По типу и приоритету - сначала все баги по приоритету, потом все таски по приоритету.
		/// </summary>
		TypePriority

	}
}