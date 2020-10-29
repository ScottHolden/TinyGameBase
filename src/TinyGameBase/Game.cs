using SkiaSharp;
using System.Collections.Generic;
using System.Windows.Documents;

namespace TinyGameBase
{
	public class Game
	{
		private readonly List<Dot> _dots;

		public Game()
		{
			_dots = new List<Dot>
			{
				new Dot(50,50),
				new Dot(100,50),
				new Dot(50,100),
				new Dot(100,100)
			};
		}

		// Called in 16ms steps
		public void Update()
		{
			foreach (Dot d in _dots)
			{
				d.Update();
			}
		}

		// Called as fast as posible, normally 60fps
		public void Render(SKCanvas canvas, int width, int height)
		{
			canvas.Clear(SKColors.LightBlue);

			foreach (Dot d in _dots)
			{
				d.Render(canvas);
			}
		}
	}
}
