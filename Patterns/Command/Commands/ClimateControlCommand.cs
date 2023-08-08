using System;
using System.Diagnostics;

namespace Command.Commands
{
	/// <summary>
	/// Команда "Климат-контроль".
	/// </summary>
	public class ClimateControlCommand: ICommand
	{
		/// <summary>
		/// Кондиционер.
		/// </summary>
		private readonly AirConditioner _airConditioner;

		/// <summary>
		/// Заданная температура.
		/// </summary>
		private readonly int _temperature;

		/// <summary>
		/// Пульт управления.
		/// </summary>
		private RemoteController _remoteController;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="airConditioner">Кондиционер</param>
		/// <param name="temperature">Целевая температура</param>
		public ClimateControlCommand(AirConditioner airConditioner, int temperature)
		{
			_airConditioner = airConditioner ?? throw new ArgumentNullException(nameof(airConditioner));
			_temperature = temperature;
		}

		/// <summary>
		/// Сделать классненько.
		/// </summary>
		public void Execute()
		{
			Trace.WriteLine($"Климат-контроль: Включен.");

			_remoteController = new RemoteController();
			
			// Если не включен - включаем.
			if (!_airConditioner.State)
			{
				_remoteController.SetCommand(new SwitchCommand(_airConditioner));
				_remoteController.PressButton();
			}

			// Если температура меньше заданной.
			if (_airConditioner.Temperature < _temperature)
			{
				_remoteController.SetCommand(new AddTemperatureCommand(_airConditioner));
				while (_airConditioner.Temperature < _temperature)
				{
					_remoteController.PressButton();
				}
			}

			// Если температура меньше заданной.
			else if (_airConditioner.Temperature > _temperature)
			{
				_remoteController.SetCommand(new DecreaseTemperatureCommand(_airConditioner));
				while (_airConditioner.Temperature > _temperature)
				{
					_remoteController.PressButton();
				}
			}

			Trace.WriteLine($"Готово. Установилась температура: {_airConditioner.Temperature}");
		}

		/// <summary>
		/// Вернуть как было.
		/// </summary>
		public void Undo()
		{
			Trace.WriteLine($"Климат-контроль: Отключен.");

			while (_remoteController.CommandsHistory.Count > 0)
			{
				_remoteController.PressUndo();
			}

			Trace.WriteLine($"Готово. Вернулась температура: {_airConditioner.Temperature}");
		}
	}
}