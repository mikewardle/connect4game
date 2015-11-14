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

		public bool ColumnFull(int column)
		{
			return Columns[column-1].All(x => x.PlayerIndex > 0);
		}

		internal void Display(Action<object> WriteLineToDisplay)
		{
			var margin = "\t";
			WriteLineToDisplay(String.Empty);

			var spacer = String.Join("---", Enumerable.Range(1, ColumnCount).Select(x => "-").ToArray());
			WriteLineToDisplay(margin + spacer);

			for (int i=RowCount -1 ; i >=0 ;i--)
			{
				var r= Columns.Select(x => x.Skip(i).First().PlayerIndex).Select(x=> MapToSymbol(x));
				var row = String.Join(" | ", r.ToArray());
				WriteLineToDisplay(margin + row);
				WriteLineToDisplay(margin + spacer);
			}
			WriteLineToDisplay(String.Empty);
		}

		private string MapToSymbol(int x)
		{
			if (x == 0)
				return " ";
			return x == 1 ? "x" : "o";
		}
	}

}
