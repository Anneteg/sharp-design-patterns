using System;

namespace Builder
{
	/// <summary>
	/// Повар.
	/// </summary>
	public class Cook
	{
		/// <summary>
		/// Приготовить окрошку.
		/// </summary>
		/// <param name="okroshkaBuilder">Строитель для окрошки</param>
		/// <returns>Окрошка</returns>
		public Okroshka CookOkroshka(IOkroshkaBuilder okroshkaBuilder)
		{
			if (okroshkaBuilder == null)
			{
				throw new ArgumentNullException(nameof(okroshkaBuilder));
			}

			okroshkaBuilder.AddMainIngredients();
			okroshkaBuilder.AddAdditionalIngredients();
			okroshkaBuilder.PourOver();

			return okroshkaBuilder.GetResult();
		}
	}
}