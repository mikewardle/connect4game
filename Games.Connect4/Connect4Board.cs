using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Games.Connect4
{
	class Connect4Board
	{
		public int RowCount { get; private set; }
		public Counter[][] Columns { get; private set; }
		public int ColumnCount { get { return Columns.Length; } }
		public Connect4Board(int rows, int columns)
		{
			RowCount = rows;
			Columns = Enumerable.Range(1,columns).Select(x=> new Counter[RowCount]).ToArray();
		}
	}
}
