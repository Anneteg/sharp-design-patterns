namespace Command
{
	/// <summary>
	/// Интерфейс команды.
	/// </summary>
	public interface  ICommand
	{
		/// <summary>
		/// Выполнить.
		/// </summary>
		void Execute();

		/// <summary>
		/// Отменить.
		/// </summary>
		void Undo();
	}
}
