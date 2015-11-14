using Games.Core;
using System;

namespace Games.Connect4.Players
{
	public abstract class Connect4Player :IPlayer
	{
		public int PlayerNumber { get; set; }

		public abstract int GetColumnSelected(Func<string> QueryPlayer, Action<object> WriteLineToDisplay, int minValue, int maxValue);
	}
}
