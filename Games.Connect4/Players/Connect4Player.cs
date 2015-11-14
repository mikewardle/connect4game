using Games.Core;

namespace Games.Connect4.Players
{
	public abstract class Connect4Player :IPlayer
	{
		public int PlayerNumber { get; set; }

		internal abstract string GetColumnSelected(System.Func<string> QueryPlayer);
	}
}
