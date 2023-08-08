using System.Diagnostics;

namespace Strategy.Strategies
{
	/// <summary>
	/// Стратегия отдыха.
	/// </summary>
	public class RestStrategy : IStrategy
	{
		/// <summary>
		/// Выполнить стратегию.
		/// </summary>
		public void Execute()
		{
			Trace.WriteLine($"Ура, наконец-то есть время поделать карьерные цели!\n");
		}
	}
}