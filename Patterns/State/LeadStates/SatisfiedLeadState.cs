using System;

namespace State.LeadStates
{
	/// <summary>
	/// Реализация состояния "Потребность удовлетворена" лида.
	/// </summary>
	public class SatisfiedLeadState : ILeadState
	{
		/// <summary>
		/// Название стадии.
		/// </summary>
		public string StateName { get; } = "Потребность удовлетворена";

		/// <summary>
		/// Код стадии.
		/// </summary>
		public string StateCode { get; } = "Satisfied";

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

			// Стадия "Потребность удовлетворена" конечная, дальнейшие переходы запрещены.
			return lead.GetCurrentState();
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

			// Стадия "Потребность удовлетворена" конечная, дальнейшие переходы запрещены.
			return lead.GetCurrentState();
		}
	}
}