using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Games.Core;

namespace Games.Connect4
{
	public class Connect4Board
	{
		public int RowCount { get; private set; }
		public Counter[][] Columns { get; private set; }
		public int ColumnCount { get { return Columns.Length; } }
		public Connect4Board(int rows, int columns)
		{
			RowCount = rows;
			Columns = Enumerable.Range(1,columns)
								.Select(x=> Enumerable.Range(1,RowCount)
														.Select(y => new Counter())
														.ToArray())
								.ToArray();
		}

		public void AddCounter(int playerId, int columnSelected)
		{
			//remember arrays are zero indexed
			var column = Columns[columnSelected - 1];
			var indexOfFirstEmptyCell = column.FindIndex(x => x.PlayerIndex == 0);
			column[indexOfFirstEmptyCell].PlayerIndex = playerId;
		}
	}

}
