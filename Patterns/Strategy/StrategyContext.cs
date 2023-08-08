using System;

namespace Strategy
{
	/// <summary>
	/// Контекст для работы со стратегиями.
	/// </summary>
	public class StrategyContext
	{
		/// <summary>
		/// Стратегия.
		/// </summary>
		private IStrategy _strategy;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="strategy"></param>
		public void SetStrategy(IStrategy strategy)
		{
			_strategy = strategy ?? throw new ArgumentNullException(nameof(strategy));
		}

		/// <summary>
		/// Выполнить стратегию.
		/// </summary>
		public void ExecuteStrategy()
		{
			_strategy.Execute();
		}
	}
}