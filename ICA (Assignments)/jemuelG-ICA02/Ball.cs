using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace jemuelG_ICA02_Bouncy
{
    internal class Ball
    {
        private static Random rnd = new Random();   //static field random, initialized

        private int _radius;                        //ball radius
        public int Radius                           //public manual set property
        {
            set
            {
                //if statement to keep range between 5 - 100
                if (value < 1)
                {
                    _radius = 1;
                }
                else if (value > 100)
                {
                    _radius = 100;
                }
                else
                {
                    _radius = value;
                }
            }
        }

        public Vector2 Center { get; private set; }     //Center ball location (x,y)
        public Vector2 Velocity { get; private set; }   //Velocity of the ball (x,y)

        private Color _color;                           //Represent ball color - no property

        private int _opacity;                           //Opacity for the ball
        public int Opacity                              //public manual property for opacity
        {
            set
            {
                int num = Math.Abs(value);              //absolute value for the user input

                //Keep values between 64 - 255
                if(num < 64)
                {
                    _opacity = 64;
                }
                else if (num > 255)
                {
                    _opacity = 255;
                }
                else
                {
                    _opacity = num;
                }
            }
        }

        /* Method:      public Ball(Point startPoint)
         * Purpose:     accepts Point position and initializes the properties of the ball
         * Paramaters:  Point startPoint
         * Returns:     nothing
         */
        public Ball(Point startPoint)
        {
            Center = new Vector2(startPoint.X, startPoint.Y);

            _color = RandColor.GetColor();

            Radius = rnd.Next(30, 101);

            Velocity = new Vector2((float)rnd.NextDouble() * 20 - 10, (float)rnd.NextDouble() * 20 - 10);

            Opacity = 128;

        }

        /* Method:      public void MoveBall(CDrawer drawer)
         * Purpose:     Move ball to its new location and determine the borders to where the balls off from
         * Paramaters:  Cdrawer drawer
         * Returns:     nothing
         */
        public void MoveBall(CDrawer drawer)
        {
            Center += Velocity; //new center location

            //if satements to determine the x velocity of the ball, as well as set borders
            if(Center.X - _radius < 0)
            {
                Velocity *= new Vector2(-1, 1);         //changes velocity of x
                Center = new Vector2(_radius, Center.Y);    //set the center position based on the velocity
            }
            else if(Center.X + _radius > drawer.ScaledWidth)
            {
                Velocity *= new Vector2(-1, 1);         //changes velocity of x
                Center = new Vector2(drawer.ScaledWidth - _radius, Center.Y);   //set the center position based on the velocity
            }

            //if satements to determine the y velocity of the ball, as well as set borders
            if (Center.Y - _radius < 0)
            {
                Velocity *= new Vector2(1, -1);         //changes velocity of y
                Center = new Vector2(Center.X, _radius);    //set the center position based on the velocity
            }
            else if (Center.Y + _radius > drawer.ScaledHeight)
            {   
                Velocity *= new Vector2(1, -1);         //changes velocity of y
                Center = new Vector2(Center.X, drawer.ScaledHeight - _radius);  //set the center position based on the velocity
            }
        }

        /* Method:      public void ShowBall(CDrawer drawer)
         * Purpose:     Allows ball to draw and render.
         * Paramaters:  Cdrawer drawer
         * Returns:     nothing
         */
        public void ShowBall(CDrawer drawer)
        {
            drawer.AddCenteredEllipse((int)Center.X, (int)Center.Y, _radius * 2, _radius * 2, Color.FromArgb(_opacity, _color));    //continously draw and render the ball
        }
        /* Method:      public override string ToString()
         * Purpose:     provide location, radius and opacity in the form
         * Returns:     string override back to the main form
         */
        public override string ToString()
        {
            return $"{Center} - Radius : {_radius}, Opacity : {_opacity}";
        }

    }
}
