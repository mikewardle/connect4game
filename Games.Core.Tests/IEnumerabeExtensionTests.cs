using System;
using Games.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Games.Core.Tests
{
	[TestClass]
	public class IEnumerabeExtensionTests
	{
		[TestMethod]
		public void Get4InARowReturnsCorrectWhenPresent()
		{
			var result = new[] { 1, 2, 1, 1, 1, 1, 2, 3, 4 }.Get4InRowFromEnumerable();
			Assert.AreEqual(1, result);
		}

		[TestMethod]
		public void Get4InARowReturnsZeroWhenAbsent()
		{
			var result = new[] { 1, 2, 1, 2, 1, 1, 2, 3, 4 }.Get4InRowFromEnumerable();
			Assert.AreEqual(0, result);
		}
	}
}
