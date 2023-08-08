using System;

namespace State.LeadStates
{
	/// <summary>
	/// Реализация состояния "Квалификация" лида.
	/// </summary>
	public class QualificationLeadState : ILeadState
	{
		/// <summary>
		/// Название стадии.
		/// </summary>
		public string StateName { get; } = "Квалификация лида";

		/// <summary>
		/// Код стадии.
		/// </summary>
		public string StateCode { get; } = "Qualification";

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

			return new NurturingLeadState();
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

			// Из стадии "Квалификация лида" можем перейти только на "Взращивание", "Перевод в продажу" или "Дисквалифицирован".
			// Иначе сохраняется текущая стадия.
			if (state.StateCode == "Nurturing" || state.StateCode == "HandoffToSales" ||
				state.StateCode == "Disqualified")
			{
				return state;
			}

			return lead.GetCurrentState();
		}
	}
}