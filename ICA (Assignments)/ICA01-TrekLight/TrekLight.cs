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
        Color _LightColor;  //Type Color
        byte _on;           //byte _on
        byte _tick;         //byte _tick
        int bWidth;         //Int bWidth 

        //Custom Constructor for trekLight with bWidth default value of 2
        //Accepts Color, byte representing on, and bwidtrh border equal to 2
        public TrekLight(Color lightColor, byte on, int bWidth = 2)
        {
            Random rand = new Random();     //initialize random number

            _LightColor = lightColor;       
            _on = on;
            _tick = (byte)rand.Next(0, 255);    //set random value range from 0 to 255
            this.bWidth = bWidth;               //default border
        }

        //Default Constructor for trekLight and making _on vlaue eqaul to 64, randomly generated color and
        //border width of 6
        public TrekLight() : this(Color.FromArgb(new Random().Next(256),
            new Random().Next(256),
            new Random().Next(256), 6), 64, 6)
        {
        }

         /* Method:     public void Tick()
         * Purpose:     Body will Increment _byTick value by 3
         * Paramaters:  nothing
         * Returns:     nothing
         */
        public void Tick()
        {
            _tick += 3;
        }

        /* Method:     public void RenderLight(CDrawer drawer, int num)
        * Purpose:     Render the added Light based on the chosen key
        * Paramaters:  CDrawer drawer, int num
        * Returns:     nothing
        */
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
        /* Method:     public void RedAlert()
        * Purpose:     immediately place the TrekLight into its on state.
        * Paramaters:  nothing
        * Returns:     nothing
        */
        public void RedAlert()
        {
            _tick = _on;
        }
    }
}
