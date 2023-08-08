namespace State
{
	/// <summary>
	/// Интерфейс для работы со стадиями лида.
	/// </summary>
	public interface ILeadState
	{
		/// <summary>
		/// Название стадии.
		/// </summary>
		string StateName { get; }

		/// <summary>
		/// Код стадии.
		/// </summary>
		string StateCode { get; }

		/// <summary>
		/// Получить следующую стадию.
		/// </summary>
		/// <param name="lead">Лид</param>
		/// <returns>Текущая стадия</returns>
		ILeadState GetNextState(Lead lead);

		/// <summary>
		/// Получить изменение стадии.
		/// </summary>
		/// <param name="lead">Лид</param>
		/// <param name="state">Новая стадия</param>
		/// <returns>Текущая стадия</returns>
		ILeadState GetChangeState(Lead lead, ILeadState state);
	}
}
