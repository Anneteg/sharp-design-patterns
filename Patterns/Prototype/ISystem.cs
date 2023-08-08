namespace Prototype
{
	/// <summary>
	/// Интерфейс системы.
	/// </summary>
	public interface ISystem
	{
		/// <summary>
		/// Создать копию системы.
		/// </summary>
		/// <returns></returns>
		ISystem Clone();

		/// <summary>
		/// Получить информацию о системе.
		/// </summary>
		string GetInfo();
	}
}