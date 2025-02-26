using System;
using System.Windows;
using System.Windows.Media;

namespace RadarBase
{
    class MapBackground
    {
        enum Directions
        {
            East,
            South,
            West,
            North
        };

        private int ViewRange = 4000;       // 화면에 표시하는 밤지름 범위
        private int CastingRange = 1500;    // 케스팅 가능한 기본 범위
        private const int compassFontSize = 16;
        private float Pixel = 0f;
        public void Draw(int width,int height, DrawingContext dc)
        {
            Pixel = (float)width / ((float)ViewRange * 2f);


            drawCircle(dc, width/2, height/2, Pixel * (CastingRange / 2));
            drawDirectionText(dc, Directions.East, width / 2, Pixel * (CastingRange / 2) + 12, 0);
            drawDirectionText(dc, Directions.South, width / 2, Pixel * (CastingRange / 2) + 12, 90);
            drawDirectionText(dc, Directions.West, width / 2, Pixel * (CastingRange / 2) + 12, 180);
            drawDirectionText(dc, Directions.North, width / 2, Pixel * (CastingRange / 2) + 12, 270);
        }


        private void drawCircle(DrawingContext dc, int x, int y, float radius)
        {
            Pen outlinePen = new Pen(Brushes.Black, 2);
            dc.DrawEllipse(null, outlinePen, new Point(x, y), radius, radius);
        }

        private void drawDirectionText(DrawingContext dc, Directions directions, int center,float radius, float angle)
        {
            double radians = angle * Math.PI / 180f;
            double x = center + radius * Math.Cos(radians) - 8;
            double y = center + radius * Math.Sin(radians) - 8;

            FormattedText formattedText = new FormattedText(
                directions switch
                {
                    Directions.West => "서",
                    Directions.East => "동",
                    Directions.North => "북",
                    Directions.South => "남",
                    _ => throw new NotImplementedException()
                },
                System.Globalization.CultureInfo.InvariantCulture,
                FlowDirection.LeftToRight,
                new Typeface("Arial"),
                compassFontSize,    // 폰트 크기
                Brushes.Gray,       // 폰트 색상
                MapDraw.DPI//VisualTreeHelper.GetDpi(dc).PixelsPerDip // DPI 설정
            );

            dc.DrawText(formattedText, new Point(x, y));
        }

    }
}
