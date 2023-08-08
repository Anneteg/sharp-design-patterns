﻿namespace Builder.OkroshkaBuilders
{
	/// <summary>
	/// Приготовить особенную окрошку (это правда вкусно, не пугайтесь)).
	/// </summary>
	public class SpecialOkroshkaBuilder : IOkroshkaBuilder
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
			okroshka.AddIngredient("килька в томатном соусе!");
			okroshka.AddIngredient("картофель");
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
			okroshka.AddIngredient("майонез");
		}

		/// <summary>
		/// Залить.
		/// </summary>
		public void PourOver()
		{
			okroshka.AddIngredient("хлебный квас");
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