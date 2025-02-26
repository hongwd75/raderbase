using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RadarBase
{
    class MapDraw
    {
        private Canvas _canas;
        private MapBackground background;
        public System.Action<int, int, DrawingContext> drawItems;
        public static int DPI = 96;  // 그래픽 DPI 설정값
        public MapDraw(Canvas c)
        {
            _canas = c;
            // 배경
            background = new MapBackground();
            drawItems += background.Draw;

            // 몹

            // 케릭터 
        }

        public void DrawAll()
        {
            // 더블 버퍼링을 위한 비트맵 생성
            int width = (int)_canas.ActualWidth;
            int height = (int)_canas.ActualHeight;
            int rectsize = 0;

            rectsize = width < height ? width : height;
            if (rectsize == 0) return;
            RenderTargetBitmap renderBitmap = new RenderTargetBitmap(rectsize, rectsize, MapDraw.DPI, MapDraw.DPI, PixelFormats.Pbgra32);

            DrawingVisual visual = new DrawingVisual();
            using (DrawingContext dc = visual.RenderOpen())
            {
                dc.DrawRectangle(Brushes.White, null, new Rect(0, 0, rectsize, rectsize));

                drawItems?.Invoke(rectsize, rectsize, dc);
            }

            renderBitmap.Render(visual);

            _canas.Children.Clear();
            _canas.Children.Add(new Image
            {
                Source = renderBitmap
            });
        }
    }
}
