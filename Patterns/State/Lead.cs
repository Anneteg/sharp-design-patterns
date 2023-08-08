using System;
using State.LeadStates;

namespace State
{
	/// <summary>
	/// Лид.
	/// </summary>
	public class Lead
	{
		/// <summary>
		/// Стадия лида.
		/// </summary>
		private ILeadState _state;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="state">Текущее состояние.</param>
		public Lead(ILeadState state)
		{
			_state = state ?? throw new ArgumentNullException(nameof(state));
		}

		/// <summary>
		/// Получить текущую стадию лида.
		/// </summary>
		/// <returns></returns>
		public ILeadState GetCurrentState()
		{
			return _state;
		}

		/// <summary>
		/// Изменить стадию лида.
		/// </summary>
		/// <param name="state">Новая стадия</param>
		public void ChangeState(ILeadState state)
		{
			if (state == null)
			{
				throw new ArgumentNullException(nameof(state));
			}

			_state = _state.GetChangeState(this, state);
		}

		/// <summary>
		/// Перейти на следующую стадию.
		/// </summary>
		public void NextState()
		{
			_state = _state.GetNextState(this);
		}
	}
}