using System;
using System.Collections.Generic;
namespace Builder
{
	/// <summary>
	/// Окрошка.
	/// </summary>
	public class Okroshka
	{
		/// <summary>
		/// Список ингредиентов.
		/// </summary>
		private readonly List<object> _ingredients = new List<object>();

		/// <summary>
		/// Добавить ингредиент.
		/// </summary>
		/// <param name="part"></param>
		public void AddIngredient(string part)
		{
			if (part == null)
			{
				throw new ArgumentNullException(nameof(part));
			}

			_ingredients.Add(part);
		}

		/// <summary>
		/// Получить рецепт окрошки.
		/// </summary>
		/// <returns></returns>
		public string GetListIngredients()
		{
			var result = string.Join(", ", _ingredients);
			return $"Список ингредиентов: {result}.\n";
		}
	}
}