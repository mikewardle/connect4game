
using System;
using System.Threading;
namespace Games.Connect4.Players
{
	public class Connect4ComputerPlayer :Connect4Player
	{
		private static Random rand = new Random();
		internal override int  GetColumnSelected(Func<string> QueryPlayer, Action<object> WriteLinetoDisplay, int minValue, int maxValue)
		{
			WriteLinetoDisplay("The computer is thinking");
			Thread.Sleep(2000);
			return rand.Next(minValue, maxValue);
		}
	}
}
