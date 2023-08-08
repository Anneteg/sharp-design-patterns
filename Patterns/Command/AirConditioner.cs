namespace Command
{
	/// <summary>
	/// Кондиционер.
	/// </summary>
	public class AirConditioner
	{
		/// <summary>
		/// Состояние (включен/выключен).
		/// </summary>
		public bool State;

		/// <summary>
		/// Температура в градусах.
		/// </summary>
		public int Temperature = 20;

		/// <summary>
		/// Максимальная температура.
		/// </summary>
		public static int MaxTemperature = 30;

		/// <summary>
		/// Минимальная температура.
		/// </summary>
		public static int MinTemperature = 15;

		/// <summary>
		/// Переключить состояние (вкл/выкл).
		/// </summary>
		public void Switch()
		{
			State = !State;
		}

		/// <summary>
		/// Сделать прохладнее.
		/// </summary>
		public void MakeColder()
		{
			if (Temperature > MinTemperature)
			{
				Temperature--;
			}
		}

		/// <summary>
		/// Сделать теплее.
		/// </summary>
		public void MakeWarmer()
		{
			if (Temperature < MaxTemperature)
			{
				Temperature++;
			}
		}
	}
}