using System.Collections.Generic;
using System.Linq;

namespace Prototype
{
	/// <summary>
	/// Crm-система.
	/// </summary>
	public class CrmSystem : ISystem
	{
		/// <summary>
		/// Имя проекта.
		/// </summary>
		public string ProjectName;

		/// <summary>
		/// Имя продукта.
		/// </summary>
		public string ProductName;

		/// <summary>
		/// Версия продукта.
		/// </summary>
		public string Version;

		/// <summary>
		/// Список фич.
		/// </summary>
		public List<Feature> Features = new List<Feature>();

		/// <summary>
		///  Создать копию системы.
		/// </summary>
		/// <returns>Копия crm-системы</returns>
		public ISystem Clone()
		{
			var clone = (CrmSystem)MemberwiseClone();
			clone.Features = new List<Feature>();
			foreach (var feature in Features)
			{
				clone.Features.Add(feature);
			}

			return clone;
		}

		/// <summary>
		/// Получить информацию о системе.
		/// </summary>
		public string GetInfo()
		{
			return $"Проект: {ProjectName}\nПродукт {ProductName}\nВерсия: {Version}\n" +
			       $"Список фич:\n\t{string.Join("\n\t", Features.Select(f => f.Name))}";
		}
	}
}
