using System;
using System.Diagnostics;

namespace Command.Commands
{
	/// <summary>
	/// Команда "Прибавить температуру".
	/// </summary>
	public class AddTemperatureCommand : ICommand
	{
		/// <summary>
		/// Кондиционер.
		/// </summary>
		private readonly AirConditioner _airConditioner;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="airConditioner"></param>
		public AddTemperatureCommand(AirConditioner airConditioner)
		{
			_airConditioner = airConditioner ?? throw new ArgumentNullException(nameof(airConditioner));
		}

		/// <summary>
		/// Прибавить температуру.
		/// </summary>
		public void Execute()
		{
			_airConditioner.MakeWarmer();

			Trace.WriteLine($"Текущая температура: {_airConditioner.Temperature}");
		}

		/// <summary>
		/// Убавить температуру.
		/// </summary>
		public void Undo()
		{
			_airConditioner.MakeColder();

			Trace.WriteLine($"Текущая температура: {_airConditioner.Temperature}");
		}
	}
}