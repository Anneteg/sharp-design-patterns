using System;
using System.Linq;
using Iterator.Model;

namespace Iterator.Iterators
{
	/// <summary>
	/// Базовый итератор рабочих элементов.
	/// </summary>
	public class BaseWorkItemIterator : IIterator<WorkItem>
	{
		/// <summary>
		/// Доска задач.
		/// </summary>
		private readonly WorkItemsBoard _workItemsBoard;

		/// <summary>
		/// Текущая позиция.
		/// </summary>
		private int _position = -1;

		/// <summary>
		/// Конструктор.
		/// </summary>
		/// <param name="workItemsBoard">Доска задач</param>
		/// <param name="type">Тип сортировки в итераторе</param>
		public BaseWorkItemIterator(WorkItemsBoard workItemsBoard, WorkItemIteratorType type)
		{
			_workItemsBoard = workItemsBoard ?? throw new ArgumentNullException(nameof(workItemsBoard));

			switch (type)
			{
				case WorkItemIteratorType.Priority:
					PrioritySort();
					break;
				case WorkItemIteratorType.Type:
					TypeSort();
					break;
				case WorkItemIteratorType.TypePriority:
					TypePrioritySort();
					break;
				default: throw new ArgumentException($"Unexpected enum value: {type}", nameof(type));
			}
		}

		/// <summary>
		/// Текущий элемент.
		/// </summary>
		public WorkItem Current => _workItemsBoard[_position];

		/// <summary>
		/// Переключиться на следующий элемент.
		/// </summary>
		/// <returns>Признак того, что можно переключаться дальше</returns>
		public bool MoveNext()
		{
			return ++_position != _workItemsBoard.Count;
		}

		/// <summary>
		/// Сортировка по приоритету.
		/// </summary>
		private void PrioritySort()
		{
			_workItemsBoard.WorkItems = _workItemsBoard
				.WorkItems
				.OrderBy(item => item.Priority)
				.ToList();
		}

		/// <summary>
		/// Сортировка по типу.
		/// </summary>
		private void TypeSort()
		{
			_workItemsBoard.WorkItems = _workItemsBoard
				.WorkItems
				.OrderBy(item => item.Type)
				.ToList();
		}

		/// <summary>
		/// Сортировка по типу и приоритету.
		/// </summary>
		private void TypePrioritySort()
		{
			_workItemsBoard.WorkItems = _workItemsBoard
				.WorkItems
				.OrderBy(item => item.Type)
				.ThenBy(item => item.Priority)
				.ToList();
		}
	}
}