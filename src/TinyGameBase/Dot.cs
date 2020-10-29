using SkiaSharp;

namespace TinyGameBase
{
	public class Dot
	{
		private int _x;
		private int _y;
		private static readonly SKPaint DotPaint = new SKPaint
		{
			Color = SKColors.Red,
			Style = SKPaintStyle.Fill
		};

		public Dot(int x, int y)
		{
			_x = x;
			_y = y;
		}

		public void Update()
		{
			_x += 1;
			_y += 1;
		}

		public void Render(SKCanvas canvas)
		{
			canvas.DrawCircle(_x, _y, 2.0f, DotPaint);
		}
	}
}
