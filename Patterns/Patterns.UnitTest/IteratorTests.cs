using System.Collections.Generic;
using System.Diagnostics;
using Iterator;
using Iterator.Iterators;
using Iterator.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Patterns.UnitTest
{
	/// <summary>
	/// Тесты паттерна "Итератор".
	/// </summary>
	[TestClass]
	public class IteratorTests
	{
		/// <summary>
		/// Тест итератора по приоритету.
		/// </summary>
		[TestMethod]
		public void PriorityIteratorTest()
		{
			var workItemsBoard = GetWorkItemsBoard();
			var iterator = new BaseWorkItemIterator(workItemsBoard, WorkItemIteratorType.Priority);

			var expected = new List<int> { 1, 6, 7, 2, 3, 4, 5, 9, 8};
			var actual = new List<int>();

			while (iterator.MoveNext())
			{
				var item = iterator.Current;
				actual.Add(item.Number);
				Trace.WriteLine($"{item.Type} {item.Number}: \"{ item.Title}\" [Priority: {item.Priority}]");
			}

			CollectionAssert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Тест итератора по типу.
		/// </summary>
		[TestMethod]
		public void TypeIteratorTest()
		{
			var workItemsBoard = GetWorkItemsBoard();
			var iterator = new BaseWorkItemIterator(workItemsBoard, WorkItemIteratorType.Type);

			var expected = new List<int> { 6, 8, 9, 1, 2, 3, 4, 5, 7 };
			var actual = new List<int>();

			while (iterator.MoveNext())
			{
				var item = iterator.Current;
				actual.Add(item.Number);
				Trace.WriteLine($"{item.Type} {item.Number}: \"{ item.Title}\" [Priority: {item.Priority}]");
			}

			CollectionAssert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Тест итератора по типу и приоритету.
		/// </summary>
		[TestMethod]
		public void TypePriorityIteratorTest()
		{
			var workItemsBoard = GetWorkItemsBoard();
			var iterator = new BaseWorkItemIterator(workItemsBoard, WorkItemIteratorType.TypePriority);

			var expected = new List<int> { 6, 9, 8, 1, 7, 2, 3, 4, 5 };
			var actual = new List<int>();

			while (iterator.MoveNext())
			{
				var item = iterator.Current;
				actual.Add(item.Number);
				Trace.WriteLine($"{item.Type} {item.Number}: \"{ item.Title}\" [Priority: {item.Priority}]");
			}

			CollectionAssert.AreEqual(expected, actual);
		}

		/// <summary>
		/// Получить тестовую доску рабочих элементов.
		/// </summary>
		/// <returns></returns>
		private WorkItemsBoard GetWorkItemsBoard()
		{
			var workItems = new List<WorkItem>()
			{
				new WorkItem { Number = 1, Type = WorkItemType.Task, Title = "Настроить организационную структуру", Priority = 1},
				new WorkItem { Number = 2, Type = WorkItemType.Task, Title = "Добавить справочник 1", Priority = 2},
				new WorkItem { Number = 3, Type = WorkItemType.Task, Title = "Добавить справочник 2", Priority = 2},
				new WorkItem { Number = 4, Type = WorkItemType.Task, Title = "Настроить раздел", Priority = 2},
				new WorkItem { Number = 5, Type = WorkItemType.Task, Title = "Разработать бизнес-правила", Priority = 2},
				new WorkItem { Number = 6, Type = WorkItemType.Bug, Title = "Срочный баг", Priority = 1},
				new WorkItem { Number = 7, Type = WorkItemType.Task, Title = "Очень срочная задача", Priority = 1},
				new WorkItem { Number = 8, Type = WorkItemType.Bug, Title = "Мелкий баг с ревью", Priority = 3},
				new WorkItem { Number = 9, Type = WorkItemType.Bug, Title = "Обычный баг", Priority = 2}
			};

			return new WorkItemsBoard(workItems);
		}
	}
}
