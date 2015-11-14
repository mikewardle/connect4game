
namespace Games.Core
{
	public interface IGame
	{
		bool Finished { get; }
		void Display();

		void ProcessNextPlayer();
	}
}
