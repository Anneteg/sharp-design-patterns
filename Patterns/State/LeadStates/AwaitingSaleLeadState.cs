using System;

namespace State.LeadStates
{
	/// <summary>
	/// Реализация состояния "Ожидание продажи" лида.
	/// </summary>
	public class AwaitingSaleLeadState : ILeadState
	{
		/// <summary>
		/// Название стадии.
		/// </summary>
		public string StateName { get; } = "Ожидание продажи";

		/// <summary>
		/// Код стадии.
		/// </summary>
		public string StateCode { get; } = "AwaitingSale";

		/// <summary>
		/// Получить следующую стадию.
		/// </summary>
		/// <param name="lead">Лид</param>
		/// <returns>Текущая стадия</returns>
		public ILeadState GetNextState(Lead lead)
		{
			if (lead == null)
			{
				throw new ArgumentNullException(nameof(lead));
			}

			return new SatisfiedLeadState();
		}

		/// <summary>
		/// Получить изменение стадии.
		/// </summary>
		/// <param name="lead">Лид</param>
		/// <param name="state">Новая стадия</param>
		/// <returns>Текущая стадия</returns>
		public ILeadState GetChangeState(Lead lead, ILeadState state)
		{
			if (lead == null)
			{
				throw new ArgumentNullException(nameof(lead));
			}

			if (state == null)
			{
				throw new ArgumentNullException(nameof(state));
			}

			// Из стадии "Ожидание продажи" можем перейти только на "Потребность удовлетворена", "Дисквалифицирован".
			// Иначе сохраняется текущая стадия.
			if (state.StateCode == "Satisfied" || state.StateCode == "Disqualified")
			{
				return state;
			}

			return lead.GetCurrentState();
		}
	}
}