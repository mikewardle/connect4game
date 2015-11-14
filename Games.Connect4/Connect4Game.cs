using Games.Connect4.Players;
using Games.Core;
using Games.Core.Exceptions;
using System.Collections.Generic;

namespace Games.Connect4
{
	public class Connect4Game :IGame
	{
		public int Rows {get; private set;}
		public int Columns { get; private set; }
		public Connect4Player Player1 { get; private set; }
		public Connect4Player Player2 { get; private set; }
		private Queue<Connect4Player> PlayerQueue = new Queue<Connect4Player>();

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

			PlayerQueue.Enqueue(Player1);
			PlayerQueue.Enqueue(Player2);
		}

		public bool Finished
		{
			get
			{
				//need to implement the logic of checking for four in a row
				return false;
			}
			
		}

		public void Display()
		{
			//need to be able to inject the display and perform it somehow
			throw new System.NotImplementedException();
		}

		public void ProcessNextPlayer()
		{
			//get the player
			var player = PlayerQueue.Dequeue();

			//todo - process the turn, that is ask where to place the counter and add it to the board

			//finally add the player back to the queue
			PlayerQueue.Enqueue(player);
		}
	}
}
