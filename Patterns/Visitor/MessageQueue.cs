using System;
using System.Collections.Generic;

namespace Visitor
{
	/// <summary>
	/// Очередь интеграционных сообщений.
	/// </summary>
	public class MessageQueue
	{
		/// <summary>
		/// Список сущностей.
		/// </summary>
		readonly List<IEntity> _entities = new List<IEntity>();

		/// <summary>
		/// Добавить сущность в очередь.
		/// </summary>
		/// <param name="entity">Сущность</param>
		public void Add(IEntity entity)
		{
			if (entity == null)
			{
				throw new ArgumentNullException(nameof(entity));
			}

			_entities.Add(entity);
		}

		/// <summary>
		/// Выполнить отправку всех сущностей очереди в интеграционную систему.
		/// </summary>
		/// <param name="integrationSystem">Интеграционная система</param>
		/// <returns>Признак успеха отправки</returns>
		public bool Process(IIntegrationSystem integrationSystem)
		{
			if (integrationSystem == null)
			{
				throw new ArgumentNullException(nameof(integrationSystem));
			}

			foreach (var entity in _entities)
			{
				entity.Process(integrationSystem);
			}

			return true;
		}
	}
}