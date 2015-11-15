using System;
using System.Collections.Generic;
using System.Linq;

namespace Games.Core
{
	public static class GridHelper
	{
		public static IEnumerable<IEnumerable<Tuple<int,int>>> GetNEDiagonals(int rows, int columns, int minLength)
		{
			//work up the first column
			for (int i = 0 ; i <=rows-minLength; i++)
			{
				var res = new List<Tuple<int, int>>();
				for (int x = 0 ; x < columns ; x++)
				{
					var currentY = i + x;
					if (currentY >= rows)
						break;
					res.Add(Tuple.Create(x, currentY));
				}
				yield return res;
			}
			//work across the bottom row
			for (int x = 1; x <= (columns-minLength); x++)
			{
				var res = new List<Tuple<int, int>>();
				for (int y = 0 ; y < rows;y++)
				{
					var currentX = x + y;
					if (currentX >=columns)
						break;
					res.Add(Tuple.Create(currentX, y));
				}
				yield return res;
			}

		}

		public static IEnumerable<IEnumerable<Tuple<int,int>>> GetNWDiagonals(int rows, int columns, int minLength)
		{
			//work down the first column
			for (int y = rows - 1; y >= minLength -1 ; y--)
			{
				var res = new List<Tuple<int, int>>();
				for (int x = 0; x<columns;x++)
				{
					var currentY = y-x;
					if (currentY < 0)
						break;
					res.Add(Tuple.Create(x, currentY));
				}
				yield return res;
			}
			for (int x = 1; x <= (columns - minLength); x++)
			{
				var res = new List<Tuple<int, int>>();
				for (int i = 0; i <columns- x; i++)
				{
					var currentX =x +i;
					if (currentX >= columns)
						break;
					var currentY= rows-i - 1;//need to subtract 1 for zero indexing
					if (currentY <0)
						break;
					res.Add(Tuple.Create(currentX, currentY));
				}
				yield return res;
			}

		}
	}
}
