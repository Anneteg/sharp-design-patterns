using System;

namespace State.LeadStates
{
	/// <summary>
	/// Реализация состояния "Перевод в продажу" лида.
	/// </summary>
	public class HandoffToSalesLeadState : ILeadState
	{
		/// <summary>
		/// Название стадии.
		/// </summary>
		public string StateName { get; } = "Перевод в продажу";

		/// <summary>
		/// Код стадии.
		/// </summary>
		public string StateCode { get; } = "HandoffToSales";

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

			return new AwaitingSaleLeadState();
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

			// Из стадии "Перевод в продажу" можем перейти только на "Ожидание продажи" или "Дисквалифицирован".
			// Иначе сохраняется текущая стадия.
			if (state.StateCode == "AwaitingSale" || state.StateCode == "Disqualified")
			{
				return state;
			}

			return lead.GetCurrentState();
		}
	}
}