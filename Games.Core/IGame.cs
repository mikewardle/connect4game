
namespace Games.Core
{
	public interface IGame
	{
		bool Finished { get; set; }

		void Display();

		void ProcessNextPlayer();
	}
}
