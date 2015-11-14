
using System;
namespace Games.Connect4.Players
{
	public class Connect4HumanPlayer :Connect4Player
	{
		public override int GetColumnSelected(Func<string> QueryPlayer, Action<object> WriteLineToDisplay, int minValue, int maxValue)
		{
			var columnSelected =  QueryPlayer();
			int column = 0;
			while (!Int32.TryParse(columnSelected, out column) || column < minValue|| column > maxValue)
			{
				WriteLineToDisplay(String.Format("Please enter a number between 1 and {0}", maxValue));
				columnSelected = QueryPlayer();
			}
			return column;
		}
	}
}
