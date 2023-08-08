namespace Builder.OkroshkaBuilders
{
	/// <summary>
	/// Приготовить кето-окрошку.
	/// </summary>
	public class KetoOkroshkaBuilder : IOkroshkaBuilder
	{
		/// <summary>
		/// Окрошка.
		/// </summary>
		Okroshka okroshka = new Okroshka();

		/// <summary>
		/// Добавить основные ингредиенты.
		/// </summary>
		public void AddMainIngredients()
		{
			okroshka.AddIngredient("авокадо");
			okroshka.AddIngredient("колбаса");
			okroshka.AddIngredient("куриные яйца");
			okroshka.AddIngredient("редис");
			okroshka.AddIngredient("свежий огурец");
			okroshka.AddIngredient("зеленый лук");
			okroshka.AddIngredient("соль");
		}

		/// <summary>
		/// Добавить дополнительные ингредиенты.
		/// </summary>
		public void AddAdditionalIngredients()
		{
			okroshka.AddIngredient("укроп");
			okroshka.AddIngredient("сметана");
		}

		/// <summary>
		/// Залить.
		/// </summary>
		public void PourOver()
		{
			okroshka.AddIngredient("кефир");
		}

		/// <summary>
		/// Получить результат.
		/// </summary>
		/// <returns>Окрошка</returns>
		public Okroshka GetResult()
		{
			return okroshka;
		}
	}
}