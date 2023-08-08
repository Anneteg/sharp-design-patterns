using System;

namespace Strategy
{
	/// <summary>
	/// Интерфейс для работы со стратегиями.
	/// </summary>
	public interface IStrategy
	{
		/// <summary>
		/// Выполнить стратегию.
		/// </summary>
		void Execute();
	}
}
