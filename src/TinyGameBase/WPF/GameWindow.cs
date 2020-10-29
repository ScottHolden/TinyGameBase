using System.Windows;

namespace TinyGameBase
{
	public class GameWindow : Window
	{
		private readonly Game _game;
		private readonly GameElement _gameElement;
		public GameWindow()
		{
			this.Title = "Tiny Game Base";

			_game = new Game();
			_gameElement = new GameElement(_game);

			this.Content = _gameElement;
		}
	}
}
