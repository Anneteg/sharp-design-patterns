using System.Diagnostics;
using Builder;
using Builder.OkroshkaBuilders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Patterns.UnitTest
{
	/// <summary>
	/// Тест паттерна "Строитель".
	/// </summary>
	[TestClass]
	public class BuilderTests
	{
		/// <summary>
		/// Тест строителя окрошки.
		/// </summary>
		[TestMethod]
		public void OkroshkaBuilderTest()
		{
			var cook = new Cook();

			Trace.WriteLine("Готовим традиционную окрошку.");
			var traditionalOkroshkaBuilder = new TraditionalOkroshkaBuilder();
			var traditionalOkroshka = cook.CookOkroshka(traditionalOkroshkaBuilder);
			Trace.WriteLine(traditionalOkroshka.GetListIngredients());

			Trace.WriteLine("Готовим кето-окрошку.");
			var ketoOkroshkaBuilder = new KetoOkroshkaBuilder();
			var ketoOkroshka = cook.CookOkroshka(ketoOkroshkaBuilder);
			Trace.WriteLine(ketoOkroshka.GetListIngredients());

			Trace.WriteLine("Готовим особенную окрошку, самую вкусную, как в детстве ммм...");
			var specialOkroshkaBuilder = new SpecialOkroshkaBuilder();
			var specialOkroshka = cook.CookOkroshka(specialOkroshkaBuilder);
			Trace.WriteLine(specialOkroshka.GetListIngredients());
		}
	}
}