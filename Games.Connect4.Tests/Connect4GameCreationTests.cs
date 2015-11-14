using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Games.Core;
using Rhino.Mocks;
using Games.Connect4.Players;
using Games.Core.Exceptions;

namespace Games.Connect4.Tests
{
	[TestClass]
	public class Connect4GameCreationTests
	{
		[TestMethod]
		public void CanCreateGame()
		{
			IPlayer player1 = MockRepository.GenerateMock<Connect4Player>();
			IPlayer player2 = MockRepository.GenerateMock<Connect4Player>();
			var game = new Connect4Game(rows: 7, columns: 6, player1: player1, player2: player2);
			Assert.IsNotNull(game);
			Assert.IsInstanceOfType(game, typeof(IGame));
			Assert.IsInstanceOfType(game, typeof(Connect4Game));
			
		}

		[TestMethod]
		[ExpectedException(typeof(InvalidGameConfigurationException),"Board must be between 5 and 9 rows.")]
		public void CannotCreateCreateGame_BoardTooFewRows()
		{
			IPlayer player1 = MockRepository.GenerateMock<Connect4Player>();
			IPlayer player2 = MockRepository.GenerateMock<Connect4Player>();
			var game = new Connect4Game(rows: 4, columns: 6, player1: player1, player2: player2);
			

		}

		[TestMethod]
		[ExpectedException(typeof(InvalidGameConfigurationException), "Board must be between 5 and 9 rows.")]
		public void CannotCreateCreateGame_BoardTooManyRows()
		{
			IPlayer player1 = MockRepository.GenerateMock<Connect4Player>();
			IPlayer player2 = MockRepository.GenerateMock<Connect4Player>();
			var game = new Connect4Game(rows: 10, columns: 6, player1: player1, player2: player2);


		}

		[TestMethod]
		[ExpectedException(typeof(InvalidGameConfigurationException), "Board must be between 5 and 9 columns.")]
		public void CannotCreateCreateGame_BoardTooFewColumns()
		{
			IPlayer player1 = MockRepository.GenerateMock<Connect4Player>();
			IPlayer player2 = MockRepository.GenerateMock<Connect4Player>();
			var game = new Connect4Game(rows: 7, columns: 4, player1: player1, player2: player2);


		}

		[TestMethod]
		[ExpectedException(typeof(InvalidGameConfigurationException), "Board must be between 5 and 9 columns.")]
		public void CannotCreateCreateGame_BoardTooManyColumns()
		{
			IPlayer player1 = MockRepository.GenerateMock<Connect4Player>();
			IPlayer player2 = MockRepository.GenerateMock<Connect4Player>();
			var game = new Connect4Game(rows: 7, columns: 10, player1: player1, player2: player2);


		}

		[TestMethod]
		[ExpectedException(typeof(InvalidPlayerTypeException))]
		public void CannotCreateGame_WrongPlayerType1()
		{
			IPlayer player1 = MockRepository.GenerateMock<IPlayer>();
			IPlayer player2 = MockRepository.GenerateMock<Connect4Player>();
			var game = new Connect4Game(rows: 7, columns: 6, player1: player1, player2: player2);

		}

		[TestMethod]
		[ExpectedException(typeof(InvalidPlayerTypeException))]
		public void CannotCreateGame_WrongPlayerType2()
		{
			IPlayer player2 = MockRepository.GenerateMock<IPlayer>();
			IPlayer player1 = MockRepository.GenerateMock<Connect4Player>();
			var game = new Connect4Game(rows: 7, columns: 6, player1: player1, player2: player2);

		}

	}
}
