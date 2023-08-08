using System;
using System.Collections.Generic;

namespace Command
{
	/// <summary>
	/// Пульт управления.
	/// </summary>
	public class RemoteController
	{
		/// <summary>
		/// Команда.
		/// </summary>
		private ICommand _command;

		/// <summary>
		/// История команд.
		/// </summary>
		public readonly Stack<ICommand> CommandsHistory;

		public RemoteController()
		{
			CommandsHistory = new Stack<ICommand>();
		}

		public void SetCommand(ICommand command)
		{
			_command = command ?? throw new ArgumentNullException(nameof(command));
		}

		/// <summary>
		/// Выполнить команду.
		/// </summary>
		public void PressButton()
		{
			_command?.Execute();
			CommandsHistory.Push(_command);
		}

		/// <summary>
		/// Отменить команду.
		/// </summary>
		public void PressUndo()
		{
			if (CommandsHistory.Count > 0)
			{
				var undoCommand = CommandsHistory.Pop();
				undoCommand?.Undo();
			}
		}
	}
}