using System;
using System.Diagnostics;
using Command;
using Command.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Patterns.UnitTest
{
	/// <summary>
	/// Тест паттерна "Команда".
	/// </summary>
	[TestClass]
	public class CommandTest
	{
		/// <summary>
		/// Тест команды "Климат-контроль".
		/// </summary>
		[TestMethod]
		public void ClimateControlCommandTest()
		{
			var rand = new Random();
			var currentTemperature = rand.Next(AirConditioner.MinTemperature, AirConditioner.MaxTemperature);
			var expectedTemperature = rand.Next(AirConditioner.MinTemperature, AirConditioner.MaxTemperature);

			Trace.WriteLine($"\nТекущая температура: {currentTemperature}. Хочу температуру: {expectedTemperature}\n");

			var airConditioner = new AirConditioner
			{
				Temperature = currentTemperature
			};

			var remoteController = new RemoteController();
			remoteController.SetCommand(new ClimateControlCommand(airConditioner, expectedTemperature));
			remoteController.PressButton();

			Assert.IsTrue(airConditioner.State);
			Assert.AreEqual(airConditioner.Temperature, expectedTemperature);

			Trace.WriteLine($"\nМне не нравится. Верните как было.\n");

			remoteController.PressUndo();

			Assert.IsFalse(airConditioner.State);
			Assert.AreEqual(airConditioner.Temperature, currentTemperature);
		}
	}
}