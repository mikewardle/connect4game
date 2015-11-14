using Games.Core;

namespace Games.Connect4
{
    public class Connect4Game :IGame
    {
		private int rows;
		private int columns;
		private IPlayer player1;
		private IPlayer player2;

		public Connect4Game(int rows, int columns, IPlayer player1, IPlayer player2)
		{
			// TODO: Complete member initialization
			this.rows = rows;
			this.columns = columns;
			this.player1 = player1;
			this.player2 = player2;
		}
    }
}
