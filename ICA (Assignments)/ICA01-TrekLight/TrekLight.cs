using GDIDrawer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA01_TrekLight
{
    public class TrekLight
    {
        Color _LightColor;
        byte _on;
        byte _tick;
        int bWidth;

        public TrekLight(Color lightColor, byte on, int bWidth = 2)
        {
            Random rand = new Random();

            _LightColor = lightColor;
            _on = on;
            _tick = (byte)rand.Next(0, 255);
            this.bWidth = bWidth;
        }

        public TrekLight() : this(Color.FromArgb(new Random().Next(256),
            new Random().Next(256),
            new Random().Next(256), 6), 64, 6)
        {
        }

        public void Tick()
        {
            _tick += 3;
        }

        public void RenderLight(CDrawer drawer, int num)
        {
            int position = drawer.ScaledWidth;

            int x = num % position;
            int y = num / position;

            if(_tick >= _on)
            {
                drawer.AddRectangle(x, y, 1, 1, _LightColor, bWidth, Color.Black);
            }
        }

        public void RedAlert()
        {
            _tick = _on;
        }
    }
}
