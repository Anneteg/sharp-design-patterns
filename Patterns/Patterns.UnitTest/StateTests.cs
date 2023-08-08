using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using State;
using State.LeadStates;

namespace Patterns.UnitTest
{
	/// <summary>
	/// Тесты паттерна "Состояние".
	/// </summary>
	[TestClass]
	public class StateTests
	{
		/// <summary>
		/// Тест перехода по стадиям (от первой к следующей).
		/// </summary>
		[TestMethod]
		public void SatisfiedLeadStateTest()
		{
			var qualificationLeadState = new QualificationLeadState();
			var nurturingLeadState = new NurturingLeadState();
			var handoffToSalesLeadState = new HandoffToSalesLeadState();
			var awaitingSaleLeadState = new AwaitingSaleLeadState();
			var satisfiedLeadState = new SatisfiedLeadState();

			var lead = new Lead(qualificationLeadState);
			Trace.WriteLine($"[{lead.GetCurrentState().StateName}]");

			lead.NextState();
			Trace.WriteLine($"[{lead.GetCurrentState().StateName}]");
			Assert.AreEqual(nurturingLeadState.StateName, lead.GetCurrentState().StateName);

			lead.NextState();
			Trace.WriteLine($"[{lead.GetCurrentState().StateName}]");
			Assert.AreEqual(handoffToSalesLeadState.StateName, lead.GetCurrentState().StateName);

			lead.NextState();
			Trace.WriteLine($"[{lead.GetCurrentState().StateName}]");
			Assert.AreEqual(awaitingSaleLeadState.StateName, lead.GetCurrentState().StateName);

			lead.NextState();
			Trace.WriteLine($"[{lead.GetCurrentState().StateName}]");
			Assert.AreEqual(satisfiedLeadState.StateName, lead.GetCurrentState().StateName);

			lead.NextState();
			Trace.WriteLine($"[{lead.GetCurrentState().StateName}]");
			Assert.AreEqual(satisfiedLeadState.StateName, lead.GetCurrentState().StateName);
		}

		/// <summary>
		/// Тест изменения стадий (с учетом возможных переходов).
		/// </summary>
		[TestMethod]
		public void ChangeLeadStateTest()
		{
			var qualificationLeadState = new QualificationLeadState();
			var nurturingLeadState = new NurturingLeadState();
			var handoffToSalesLeadState = new HandoffToSalesLeadState();
			var awaitingSaleLeadState = new AwaitingSaleLeadState();
			var satisfiedLeadState = new SatisfiedLeadState();
			var disqualifiedLeadState = new DisqualifiedLeadState();

			var lead = new Lead(qualificationLeadState);

			Trace.WriteLine($"{lead.GetCurrentState().StateName} -> {handoffToSalesLeadState.StateName}");
			lead.ChangeState(handoffToSalesLeadState);
			Trace.WriteLine($"[{lead.GetCurrentState().StateName}]");
			Assert.AreEqual(handoffToSalesLeadState.StateName, lead.GetCurrentState().StateName);

			Trace.WriteLine($"{lead.GetCurrentState().StateName} -> {nurturingLeadState.StateName}");
			lead.ChangeState(nurturingLeadState);
			Trace.WriteLine($"[{lead.GetCurrentState().StateName}]");
			Assert.AreEqual(handoffToSalesLeadState.StateName, lead.GetCurrentState().StateName);

			Trace.WriteLine($"{lead.GetCurrentState().StateName} -> {awaitingSaleLeadState.StateName}");
			lead.ChangeState(awaitingSaleLeadState);
			Trace.WriteLine($"[{lead.GetCurrentState().StateName}]");
			Assert.AreEqual(awaitingSaleLeadState.StateName, lead.GetCurrentState().StateName);

			Trace.WriteLine($"{lead.GetCurrentState().StateName} -> {disqualifiedLeadState.StateName}");
			lead.ChangeState(disqualifiedLeadState);
			Trace.WriteLine($"[{lead.GetCurrentState().StateName}]");
			Assert.AreEqual(disqualifiedLeadState.StateName, lead.GetCurrentState().StateName);

			Trace.WriteLine($"{lead.GetCurrentState().StateName} -> {satisfiedLeadState.StateName}");
			lead.ChangeState(satisfiedLeadState);
			Trace.WriteLine($"[{lead.GetCurrentState().StateName}]");
			Assert.AreEqual(disqualifiedLeadState.StateName, lead.GetCurrentState().StateName);
		}
	}
}