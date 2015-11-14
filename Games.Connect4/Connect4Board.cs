using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

	public static class IEnumerableExtensionMethods
	{
		///<summary>Finds the index of the first item matching an expression in an enumerable.</summary>
		///<param name="items">The enumerable to search.</param>
		///<param name="predicate">The expression to test the items against.</param>
		///<returns>The index of the first matching item, or -1 if no items match.</returns>
		public static int FindIndex<T>(this IEnumerable<T> items, Func<T, bool> predicate)
		{
			if (items == null) throw new ArgumentNullException("items");
			if (predicate == null) throw new ArgumentNullException("predicate");

			int retVal = 0;
			foreach (var item in items)
			{
				if (predicate(item)) return retVal;
				retVal++;
			}
			return -1;
		}
		///<summary>Finds the index of the first occurence of an item in an enumerable.</summary>
		///<param name="items">The enumerable to search.</param>
		///<param name="item">The item to find.</param>
		///<returns>The index of the first matching item, or -1 if the item was not found.</returns>
		public static int IndexOf<T>(this IEnumerable<T> items, T item) { return items.FindIndex(i => EqualityComparer<T>.Default.Equals(item, i)); }
	}
}
