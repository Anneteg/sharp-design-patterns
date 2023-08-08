using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Strategy;

namespace Patterns.UnitTest
{
	/// <summary>
	/// Тесты паттерна "Стратегия".
	/// </summary>
	[TestClass]
	public class StrategyTests
	{
		/// <summary>
		/// Тест на выбор стратегии.
		/// </summary>
		[TestMethod]
		public void TodayStrategyTest()
		{
			var workingDay = new DateTime(2021,07,06);
			var dayOff = new DateTime(2021, 07, 10);

			var rand = new Random();
			var remainingWork = rand.Next(0, 10);

			var strategySelector = new StrategySelector();

			Trace.WriteLine($"Сегодня рабочий день, поэтому: ");
			var context = strategySelector.SelectStrategy(workingDay);
			context.ExecuteStrategy();

			Trace.WriteLine($"Сегодня выходной день, осталось задач на {remainingWork} часов, поэтому: ");
			context = strategySelector.SelectStrategy(dayOff, remainingWork);
			context.ExecuteStrategy();
		}
	}
}