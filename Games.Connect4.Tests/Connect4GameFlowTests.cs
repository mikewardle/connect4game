using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Games.Connect4.Players;

namespace Games.Connect4.Tests
{
	[TestClass]
	public class Connect4GameFlowTests
	{
		public interface WithWriteMethod
		{
			void WriteLineToDisplay(object obj);
		}
		[TestMethod]
		public void ProcessNextPlayerCallsCorrectMethods()
		{
			var player1 = MockRepository.GenerateMock<Connect4Player>();
			var player2 = MockRepository.GenerateMock<Connect4Player>();
			var game = new Connect4Game(6, 7, player1, player2);
			var writer = MockRepository.GenerateMock<WithWriteMethod>();
			game.WriteLineToDisplay = writer.WriteLineToDisplay;
			//expect a write to screen
			writer.Expect(x => x.WriteLineToDisplay(Arg<object>.Is.Anything));
			//expect a query ofplayer one
			player1.Expect(x => x.GetColumnSelected(Arg<Func<string>>.Is.Anything, 
													Arg<Action<object>>.Is.Anything,
													Arg<Connect4Board>.Is.Anything)).Return(1);
			//expect no query pf player 2
			player2.Expect(x => x.GetColumnSelected(Arg<Func<string>>.Is.Anything, 
													Arg<Action<object>>.Is.Anything, 
													Arg<Connect4Board>.Is.Anything))
													.Repeat.Never().Return(1);

			
			game.ProcessNextPlayer();

			writer.VerifyAllExpectations();
			player1.VerifyAllExpectations();
			player2.VerifyAllExpectations();
		}
	}
}
