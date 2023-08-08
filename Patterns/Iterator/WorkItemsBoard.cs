using System;
using System.Collections.Generic;
using Iterator.Model;

namespace Iterator
{
	/// <summary>
	/// Доска рабочих элементов.
	/// </summary>
	public class WorkItemsBoard
	{
		/// <summary>
		/// Список рабочих элементов.
		/// </summary>
		private List<WorkItem> _workItems;

		/// <summary>
		/// Конструктор.
		/// </summary>
		public WorkItemsBoard(List<WorkItem> workItems)
		{
			_workItems = workItems ?? throw new ArgumentNullException(nameof(workItems));
		}

		/// <summary>
		/// Список рабочих элементов.
		/// </summary>
		public List<WorkItem> WorkItems
		{
			get => _workItems ?? (_workItems = new List<WorkItem>());
			set => _workItems = value;
		}

		/// <summary>
		/// Количество рабочих элементов.
		/// </summary>
		public int Count => _workItems.Count;

		/// <summary>
		/// Индексатор.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public WorkItem this[int index] => _workItems[index];
	}
}