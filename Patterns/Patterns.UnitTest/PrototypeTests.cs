using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prototype;

namespace Patterns.UnitTest
{
	[TestClass]
	public class PrototypeTests
	{
		/// <summary>
		/// Тест создания прототипа crm-системы.
		/// </summary>
		[TestMethod]
		public void CrmSystemPrototypeTest()
		{
			// Создаем проект crm-системы.
			var crm = new CrmSystem
			{
				ProjectName = "ДОМ.РФ (Розница)",
				ProductName = "BankSales_BankCustomerJourney_Lending_Marketing",
				Version = "7.17.0.2164",
				Features = new List<Feature>()
				{
					new Feature { Name = "Настройка раздела Лиды"},
					new Feature { Name = "Настройка раздела Продажи"}
				}
			};

			// Создаем клон crm-системы, чтобы делать прототип для другого проекта.
			if (crm.Clone() is CrmSystem clone)
			{
				Assert.AreEqual(crm.ProjectName, clone.ProjectName);
				Assert.AreEqual(crm.ProductName, clone.ProductName);
				Assert.AreEqual(crm.Version, clone.Version);
				Assert.AreEqual(crm.Features.Count, clone.Features.Count);

				clone.ProjectName = "ДОМ.РФ (КБ)";
				clone.Features.Add(new Feature {Name = "Разработка интеграции с КД"});
				clone.Features.Add(new Feature {Name = "Настройка дашбордов"});

				Trace.WriteLine($"{crm.GetInfo()}\n");
				Trace.WriteLine($"{clone.GetInfo()}\n");
			}
		}
	}
}