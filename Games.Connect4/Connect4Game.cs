using Games.Connect4.Players;
using Games.Core;
using Games.Core.Exceptions;

namespace Games.Connect4
{
	public class Connect4Game :IGame
	{
		public int Rows {get; private set;}
		public int Columns { get; private set; }
		public Connect4Player Player1 { get; private set; }
		public Connect4Player Player2 { get; private set; }

		public Connect4Game(int rows, int columns, IPlayer player1, IPlayer player2)
		{
			if (rows < 5 || rows > 9)
				throw new InvalidGameConfigurationException();
			if (columns < 5 || columns > 9)
				throw new InvalidGameConfigurationException();
			
			// TODO: Complete member initialization
			Rows = rows;
			Columns = columns;
			Player1 = player1 as Connect4Player;
			Player2 = player2 as Connect4Player;

			if (Player1 == null || Player2 == null)
				throw new InvalidPlayerTypeException();
		}

		public bool Finished
		{
			get
			{
				throw new System.NotImplementedException();
			}
			set
			{
				throw new System.NotImplementedException();
			}
		}

		public void Display()
		{
			throw new System.NotImplementedException();
		}

		public void ProcessNextPlayer()
		{
			throw new System.NotImplementedException();
		}
	}
}
