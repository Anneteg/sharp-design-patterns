using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
	/// <summary>
	/// Интерфейс интеграционного сообщения.
	/// </summary>
	public interface IEntity
	{
		/// <summary>
		/// Отправить сообщение в интеграционную систему.
		/// </summary>
		/// <param name="integrationSystem">Интеграционная система</param>
		void Process(IIntegrationSystem integrationSystem);
	}
}
