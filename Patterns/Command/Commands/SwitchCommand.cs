using System;
using System.Diagnostics;

namespace Command.Commands
{
	/// <summary>
	/// Команда "Переключатель".
	/// </summary>
	public class SwitchCommand: ICommand
	{
		/// <summary>
		/// Кондиционер.
		/// </summary>
		private readonly AirConditioner _airConditioner;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="airConditioner">Кондиционер</param>
		public SwitchCommand(AirConditioner airConditioner)
		{
			_airConditioner = airConditioner ?? throw new ArgumentNullException(nameof(airConditioner));
		}

		/// <summary>
		/// Выполнить переключение.
		/// </summary>
		public void Execute()
		{
			_airConditioner.Switch();

			Trace.WriteLine(_airConditioner.State
				? "Кондиционер включен"
				: "Кондиционер выключен");
		}

		/// <summary>
		/// Отменить переключение.
		/// </summary>
		public void Undo()
		{
			_airConditioner.Switch();

			Trace.WriteLine(_airConditioner.State
				? "Кондиционер включен"
				: "Кондиционер выключен");
		}
	}
}