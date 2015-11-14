using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Games.Connect4.Tests
{
	[TestClass]
	public class Connect4BoardTests
	{
		[TestMethod]
		public void CreateBuildsCorrectArrays()
		{
			var board = new Connect4Board(5, 2);
			Assert.AreEqual(2, board.ColumnCount);
			Assert.AreEqual(5, board.RowCount);
			Assert.AreEqual(2,board.Columns.Length);
			Assert.AreEqual(5, board.Columns[0].Length);
			Assert.AreEqual(5, board.Columns[1].Length);
		}
		[TestMethod]
		public void CreateBuildsEmptyBoard()
		{
			var board = new Connect4Board(5, 2);
			//check board is empty
			Assert.IsTrue(board.Columns.All(x => x.All(y => y.PlayerIndex ==0)));
		}
		[TestMethod]
		public void AddCounterAddsToCorrectRowAndColumnBlankBoard()
		{
			var board = new Connect4Board(5, 2);
			board.AddCounter(1, 1);
			Assert.AreEqual(1, board.Columns[0][0].PlayerIndex);

		}
		
		[TestMethod]
		public void AddCounterAddsToCorrectRowAndColumnPopulatedBoard()
		{
			var board = new Connect4Board(5, 2);
			board.Columns[0][0].PlayerIndex = 1;
			board.Columns[0][1].PlayerIndex = 2;
			board.AddCounter(1, 1);
			Assert.AreEqual(1, board.Columns[0][2].PlayerIndex);

		}


	}
}
