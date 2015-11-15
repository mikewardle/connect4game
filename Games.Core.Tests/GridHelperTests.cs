using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Games.Core.Tests
{
	[TestClass]
	public class GridHelperTests
	{
		[TestMethod]
		public void GetNEDiagonalReturnsCorrect_444()
		{
			int rows = 4;
			int columns = 4;
			int minLength = 4;
			var results = GridHelper.GetNEDiagonals(rows, columns, minLength);
			Assert.AreEqual(1, results.Count());
			Assert.AreEqual(0, results.First().First().Item1);
			Assert.AreEqual(0, results.First().First().Item2);
			Assert.IsTrue(results.First().All(x => x.Item1.Equals(x.Item2)));
		}

		[TestMethod]
		public void GetNWDiagonalReturnsCorrect_444()
		{
			int rows = 4;
			int columns = 4;
			int minLength = 4;
			var results = GridHelper.GetNWDiagonals(rows, columns, minLength);
			Assert.AreEqual(1, results.Count());
			Assert.AreEqual(0, results.First().First().Item1);
			Assert.AreEqual(rows-1, results.First().First().Item2);
			Assert.IsTrue(results.First().All(x => x.Item1 +x.Item2 ==rows-1));
		}

		[TestMethod]
		public void GetNWDiagonalReturnsCorrect_674()
		{
			int rows = 6;
			int columns = 7;
			int minLength = 4;
			var results = GridHelper.GetNWDiagonals(rows, columns, minLength);
			Assert.AreEqual(6, results.Count());
			Assert.AreEqual(0, results.First().First().Item1);
			Assert.AreEqual(rows-1, results.First().First().Item2);
			//0,5 - 5,0
			Assert.IsTrue(results.First().All(x => x.Item1 + x.Item2 == rows-1));
			Assert.IsTrue(results.Skip(1).First().All(x => x.Item1 + x.Item2 == rows-2));
			//3,5 - 6,2
			Assert.IsTrue(results.Last().All(x => x.Item1 + x.Item2 == (columns+1)));
		}

		[TestMethod]
		public void GetNEDiagonalReturnsCorrect_674()
		{
			int rows = 6;
			int columns = 7;
			int minLength = 4;
			var results = GridHelper.GetNEDiagonals(rows,columns,minLength);
			Assert.AreEqual(6, results.Count());
			Assert.AreEqual(0, results.First().First().Item1);
			Assert.AreEqual(0, results.First().First().Item2);
			Assert.IsTrue(results.First().All(x => x.Item1.Equals(x.Item2)));
			Assert.IsTrue(results.Skip(1).First().All(x => x.Item2 - x.Item1 == 1));
			Assert.IsTrue(results.Last().All(x => x.Item1 - x.Item2 == (columns - minLength)));
		}
	}
}
