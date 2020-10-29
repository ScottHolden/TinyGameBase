using System.Windows;

namespace TinyGameBase
{
	public partial class MainWindow : Window
	{
		private readonly Game _game;
		private readonly GameElement _gameElement;
		public MainWindow()
		{
			InitializeComponent();

			this.Title = "Tiny Game Base";

			_game = new Game();
			_gameElement = new GameElement(_game);

			this.Content = _gameElement;
		}
	}
}
