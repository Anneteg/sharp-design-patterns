namespace Builder
{
	/// <summary>
	/// Интерфейс для работы со строителями.
	/// </summary>
	public interface IOkroshkaBuilder
	{
		/// <summary>
		/// Добавить основные ингредиенты.
		/// </summary>
		void AddMainIngredients();

		/// <summary>
		/// Добавить дополнительные ингредиенты.
		/// </summary>
		void AddAdditionalIngredients();

		/// <summary>
		/// Залить.
		/// </summary>
		void PourOver();

		/// <summary>
		/// Получить результат.
		/// </summary>
		/// <returns></returns>
		Okroshka GetResult();

	}
}
