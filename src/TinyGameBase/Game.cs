using SkiaSharp;

namespace TinyGameBase
{
	public class Game
	{
		// Called in 16ms steps
		public void Update()
		{
		}

		// Called as fast as posible, normally 60fps
		public void Render(SKCanvas canvas, int width, int height)
		{
			canvas.Clear(SKColors.LightBlue);
		}
	}
}
