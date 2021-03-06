﻿using Games.Connect4;
using Games.Connect4.Players;
using Games.Core;
using System;

namespace TombolaGames.CMD
{
	class Program
	{
		static void Main(string[] args)
		{
			while(true)
			{
				var game = CreateGame();
				//display initial state of the game
				game.Display();
				while(!game.Finished)
				{
					//process the turn, will include prompts of the player to move etc
					game.ProcessNextPlayer();
					//display the new state of the game (will handle the display of win messages)
					game.Display();
				}
				Console.WriteLine("Play again? (y/n)");
				var res = Console.ReadLine();
				if (!res.StartsWith("y", StringComparison.OrdinalIgnoreCase))
					break;
			}
		}

		private static IGame CreateGame()
		{

			Console.WriteLine("Would you like to play a 1 or 2 player game?");
			int numberOfPlayers = -1;
			while (numberOfPlayers < 0 || numberOfPlayers > 2)
			{
				Console.WriteLine("Please enter 1 or 2.");
				Int32.TryParse(Console.ReadLine(), out numberOfPlayers);
			}
			IGame game;
			if (numberOfPlayers ==0)
				game = new Connect4Game(7, 6, new Connect4ComputerPlayer(), new Connect4ComputerPlayer());
			else if (numberOfPlayers == 1)
				game =  new Connect4Game(7, 6, new Connect4HumanPlayer(), new Connect4ComputerPlayer());
			else
				game =  new Connect4Game(7, 6, new Connect4HumanPlayer(), new Connect4HumanPlayer());

			game.WriteLineToDisplay = (obj) => Console.WriteLine(obj);
			game.ClearDisplay = () => Console.Clear();
			game.QueryPlayer = () => Console.ReadLine();

			return game;
		}
	}
}
