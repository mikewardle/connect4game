
using System;
namespace Games.Core
{
	public interface IGame
	{
		bool Finished { get; }
		void Display();

		void ProcessNextPlayer();

		Action ClearDisplay { get; set; }
		Action<object> WriteLineToDisplay { get; set; }
		Func<string> QueryPlayer { get; set; }
	}
}
