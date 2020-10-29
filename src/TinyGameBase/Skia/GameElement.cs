using SkiaSharp;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TinyGameBase
{
	public class GameElement : FrameworkElement
    {
        private readonly bool _designMode;
        private readonly Game _game;
        private WriteableBitmap _bitmap;
        private TimeSpan _lastRenderingTime = TimeSpan.Zero;
        private TimeSpan _lastUpdateTime = TimeSpan.Zero;
        private static readonly TimeSpan UpdateStepSize = TimeSpan.FromMilliseconds(16);

        public GameElement(Game game)
        {
            _designMode = DesignerProperties.GetIsInDesignMode(this);
            _game = game;
            CompositionTarget.Rendering += CompositionTargetRendering;
            CompositionTarget.Rendering += GameUpdate;
        }

        private void GameUpdate(object sender, EventArgs e)
        {
            var args = (RenderingEventArgs)e;
            
            while (_lastUpdateTime < args.RenderingTime)
            {
                _game.Update();
                _lastUpdateTime = _lastUpdateTime.Add(UpdateStepSize);
            }
        }

        private void CompositionTargetRendering(object sender, EventArgs e)
        {
            var args = (RenderingEventArgs)e;

            if (_lastRenderingTime == args.RenderingTime)
            {
                return;
            }

            _lastRenderingTime = args.RenderingTime;

            InvalidateVisual();
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (_designMode)
                return;

            int width = (int)this.ActualWidth;
            int height = (int)this.ActualHeight;

            // Only resize if we need to
            if (_bitmap == null || width != _bitmap.PixelWidth || height != _bitmap.PixelHeight)
            {
                _bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Pbgra32, null);
            }

            if (_bitmap == null)
                return;

            SKImageInfo info = new SKImageInfo(_bitmap.PixelWidth, _bitmap.PixelHeight, SKImageInfo.PlatformColorType, SKAlphaType.Premul);

            _bitmap.Lock();

            // Render the game
            using (var surface = SKSurface.Create(info, _bitmap.BackBuffer, _bitmap.BackBufferStride))
            {
                _game.Render(surface.Canvas, _bitmap.PixelWidth, _bitmap.PixelHeight);
            }

            _bitmap.AddDirtyRect(new Int32Rect(0, 0, info.Width, info.Height));

            _bitmap.Unlock();

            drawingContext.DrawImage(_bitmap, new Rect(0, 0, this.ActualWidth, this.ActualHeight));

        }
    }
}
