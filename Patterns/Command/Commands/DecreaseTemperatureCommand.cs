using System;
using System.Diagnostics;

namespace Command.Commands
{
	/// <summary>
	/// Команда "Уменьшить температуру".
	/// </summary>
	public class DecreaseTemperatureCommand : ICommand
	{
		/// <summary>
		/// Кондиционер.
		/// </summary>
		private readonly AirConditioner _airConditioner;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="airConditioner"></param>
		public DecreaseTemperatureCommand(AirConditioner airConditioner)
		{
			_airConditioner = airConditioner ?? throw new ArgumentNullException(nameof(airConditioner));
		}

		/// <summary>
		/// Убавить температуру.
		/// </summary>
		public void Execute()
		{
			_airConditioner.MakeColder();

			Trace.WriteLine($"Текущая температура: {_airConditioner.Temperature}");
		}

		/// <summary>
		/// Прибавить температуру.
		/// </summary>
		public void Undo()
		{
			_airConditioner.MakeWarmer();

			Trace.WriteLine($"Текущая температура: {_airConditioner.Temperature}");
		}
	}
}