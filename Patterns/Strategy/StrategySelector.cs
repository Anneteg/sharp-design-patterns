using System;
using Strategy.Strategies;

namespace Strategy
{
	/// <summary>
	/// Класс для выбора стратегии.
	/// </summary>
	public class StrategySelector
	{
		/// <summary>
		/// Выбрать стратегию.
		/// </summary>
		/// <param name="date">Дата</param>
		/// <param name="remainingWork">Оставшаяся работа (в часах)</param>
		/// <returns>Контекст стратегии</returns>
		public StrategyContext SelectStrategy(DateTime date, int remainingWork = 0)
		{
			var context = new StrategyContext();
			
			// Если не выходной или осталось много работы, то работаем.
			if ((date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) && remainingWork < 4)
			{
				context.SetStrategy(new RestStrategy());
			}
			else
			{
				context.SetStrategy(new WorkStrategy());
			}

			return context;
		}
	}
}