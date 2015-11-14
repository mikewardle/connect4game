
using System;
using System.Threading;
namespace Games.Connect4.Players
{
	public class Connect4ComputerPlayer :Connect4Player
	{
		private static Random rand = new Random();
		public override int  GetColumnSelected(Func<string> QueryPlayer, Action<object> WriteLinetoDisplay, Connect4Board board)
		{
			WriteLinetoDisplay("The computer is thinking");
			Thread.Sleep(2000);
			return rand.Next(1, board.ColumnCount);
		}
	}
}
