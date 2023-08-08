namespace Iterator.Iterators
{
	/// <summary>
	/// Интерфейс итератора рабочих элементов.
	/// </summary>
	public interface IIterator<out T>
	{
		/// <summary>
		/// Текущий элемент.
		/// </summary>
		/// <returns>Рабочий элемент</returns>
		T Current { get; }

		/// <summary>
		/// Переключить на следующую позицию в случае, если коллекция не закончилась.
		/// </summary>
		/// <returns>Признак того, что коллекция не закончилась и позиция переключена</returns>
		bool MoveNext();
	}
}
