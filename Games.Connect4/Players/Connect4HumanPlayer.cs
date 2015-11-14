
using System;
namespace Games.Connect4.Players
{
	public class Connect4HumanPlayer :Connect4Player
	{
		public override int GetColumnSelected(Func<string> QueryPlayer, Action<object> WriteLineToDisplay, Connect4Board board)
		{
			var columnSelected =  QueryPlayer();
			int column = 0;
			while (!Int32.TryParse(columnSelected, out column) || column < 1|| column > board.ColumnCount)
			{
				WriteLineToDisplay(String.Format("Please enter a number between 1 and {0}", board.ColumnCount));
				columnSelected = QueryPlayer();
			}
			return column;
		}
	}
}
