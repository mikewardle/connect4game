using Games.Connect4;
using Games.Connect4.Players;
using Games.Core;
using System;

namespace TombolaGames.CMD
{
	class Program
	{
		static void Main(string[] args)
		{
			var game = CreateGame();
		}

		private static IGame CreateGame()
		{
			Console.WriteLine("Would you like to play a 1 or 2 player game?");
			int numberOfPlayers = -1;
			while (numberOfPlayers < 1 || numberOfPlayers > 2)
			{
				Console.WriteLine("Please enter 1 or 2.");
				Int32.TryParse(Console.ReadLine(), out numberOfPlayers);
			}
			if (numberOfPlayers == 1)
				return new Connect4Game(7, 6, new Connect4HumanPlayer(), new Connect4ComputerPlayer());
			return new Connect4Game(7, 6, new Connect4HumanPlayer(), new Connect4HumanPlayer());
		}
	}
}
