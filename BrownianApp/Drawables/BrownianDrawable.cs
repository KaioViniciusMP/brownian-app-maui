using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics;

namespace BrownianApp.Drawables
{
    public class BrownianDrawable : IDrawable
    {
        private double[] _prices;
        public double[] Prices
        {
            get => _prices;
            set
            {
                _prices = value;
                OnPricesUpdated?.Invoke();
            }
        }

        public event Action OnPricesUpdated;
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            if (Prices == null || Prices.Length == 0)
                return;

            canvas.StrokeColor = Colors.MediumPurple;
            canvas.StrokeSize = 1.5f;

            float width = (float)dirtyRect.Width;
            float height = (float)dirtyRect.Height;

            double max = Prices.Max();
            double min = Prices.Min();
            double range = max - min;

            float stepX = width / (Prices.Length - 1);

            for (int i = 1; i < Prices.Length; i++)
            {
                float x1 = (i - 1) * stepX;

                if (range == 0) range = 1;
                float y1 = height - (float)((Prices[i - 1] - min) / range * height);

                float x2 = i * stepX;
                float y2 = height - (float)((Prices[i] - min) / (max - min) * height);

                canvas.DrawLine(x1, y1, x2, y2);
            }
        }
    }
}
