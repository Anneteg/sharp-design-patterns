using System.Diagnostics;

namespace Strategy.Strategies
{
	/// <summary>
	/// Стратегия работы.
	/// </summary>
	public class WorkStrategy : IStrategy
	{
		/// <summary>
		/// Выполнить стратегию.
		/// </summary>
		public void Execute()
		{
			Trace.WriteLine($"Работаем любимую работку!\n");
		}
	}
}