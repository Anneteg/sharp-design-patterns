using System;

namespace State.LeadStates
{
	/// <summary>
	/// Реализация состояния "Взращивание" лида.
	/// </summary>
	public class NurturingLeadState : ILeadState
	{
		/// <summary>
		/// Название стадии.
		/// </summary>
		public string StateName { get; } = "Взращивание лида";

		/// <summary>
		/// Код стадии.
		/// </summary>
		public string StateCode { get; } = "Nurturing";

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

			return new HandoffToSalesLeadState();
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

			// Из стадии "Взращивание" можем перейти только на "Перевод в продажу" или "Дисквалифицирован".
			// Иначе сохраняется текущая стадия.
			if (state.StateCode == "HandoffToSales" || state.StateCode == "Disqualified")
			{
				return state;
			}

			return lead.GetCurrentState();
		}
	}
}