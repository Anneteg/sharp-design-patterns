using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitOfWork.Context;
using UnitOfWork.Model;
using System;
using UnitOfWork.Constant;

namespace Patterns.UnitTest
{
	/// <summary>
	/// Тесты паттерна "Unit Of Work".
	/// </summary>
	[TestClass]
	public class UnitOfWorkTests
	{
		/// <summary>
		/// Тест паттерна "Unit Of Work".
		/// </summary>
		[TestMethod]
		public void UnitOfWorkTest()
		{

			#region Подготовка данных

			var contactId = Guid.NewGuid();

			var contact = new Contact
			{
				Id = contactId,
				Name = "Николаев Сидор Васильевич"
			};

			var errorContactId = Guid.NewGuid();

			var errorContact = new Contact
			{
				Id = errorContactId,
				Name = "Николаев Игорь Васильевич"
			};

			var activityId = Guid.NewGuid();

			var activity = new Activity
			{
				Id = activityId,
				Title = "Позвонить маме!",
				StartDate = DateTime.UtcNow,
				DueDate = DateTime.UtcNow.AddMinutes(30),
				StatusId = ActivityConstants.NotStartedStatusId,
				CategoryId = ActivityConstants.ToDoCategoryId,
				TypeId = ActivityConstants.TaskTypeId
			};

			#endregion

			// Делаем всякие операции с БД.
			using (var unitOfWork = new UnitOfWork.UnitOfWork(new CrmContext("db")))
			{
					unitOfWork.CreateTransaction();

					unitOfWork.ContactRepository.Insert(contact);
					unitOfWork.ActivityRepository.Insert(activity);

					unitOfWork.Commit();

					unitOfWork.CreateTransaction();

					activity.StatusId = ActivityConstants.InProgressStatusId;
					unitOfWork.ActivityRepository.Update(activity);

					unitOfWork.Commit();

					unitOfWork.CreateTransaction();

					unitOfWork.ContactRepository.Insert(errorContact);

					// передумали:
					unitOfWork.Rollback();
			}

			// Проверяем, чего получилось.
			using (var unitOfWork = new UnitOfWork.UnitOfWork(new CrmContext("db")))
			{
				var resultContact = unitOfWork.ContactRepository.GetById(contactId);
				Assert.IsNotNull(resultContact);
				Assert.AreEqual(contact.Name, resultContact.Name);


				var resultActivity = unitOfWork.ActivityRepository.GetById(activityId);
				Assert.IsNotNull(resultActivity);
				Assert.AreEqual(activity.Title, resultActivity.Title);

				// Убеждаемся, что последний контакт не записался.
				var resultNewContact = unitOfWork.ContactRepository.GetById(errorContactId);
				Assert.IsNull(resultNewContact);
			}
		}
	}
}
