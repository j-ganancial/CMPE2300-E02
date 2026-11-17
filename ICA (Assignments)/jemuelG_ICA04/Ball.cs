using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using GDIDrawer;

namespace jemuelG_ICA04
{
    internal class Ball
    {
        private static CDrawer _drawer = null;          // static drawer, null until static ctor runs
        private static Random _rand = new Random();     // static random with initializer

        private int _radius;                            // ball radius
        private Color _color;                           // ball color
        private Point _center;                         // ball center       

        /* Static constructor: allocates the drawer with defaults, random background,
         * continuous update off */
        static Ball()
        {
            _drawer = new CDrawer(bContinuousUpdate: false);
            _drawer.BBColour = RandColor.GetColor();
        }
        public int Radius
        {
            set
            {
                if (value != 0)
                {
                    _radius = Math.Abs(value);
                }
                    
            }
        }
        public Ball(int radius)
        {
            _color = RandColor.GetColor();

            Radius = radius;

            // Make sure the entire ball stays inside the drawer
            _center = new Point(
                _rand.Next(_radius, _drawer.ScaledWidth - _radius),
                _rand.Next(_radius, _drawer.ScaledHeight - _radius)
            );
        }

        /* Method:     public void AddBall()
        * Purpose:     Adds Centered Elipse Drawing
        * Paramaters:  nothing
        * Returns:     nothing
        */
        public void AddBall()
        {
            _drawer.AddCenteredEllipse(_center.X, _center.Y, _radius * 2, _radius * 2, _color);
        }

        //Static ball loading set only no get, acts as a switch
        public static bool Loading
        {
            set
            {
                //if true , clears drawer otherwise false which renders drawer
                if (value)
                {
                    _drawer.Clear();
                }
                else
                {
                    _drawer.Render();
                }
            }
        }

        //Set the supplied point to set the placement of the Cdrawer
        public static Point DrawerPosition
        {
            set
            {
                _drawer.Position = value;
            }
        }

        /* Method:     private static double Distance(Ball first, Ball second)
        * Purpose:     Adds Centered Elipse Drawing
        * Paramaters:  Ball First, ball second
        * Returns:     nothing
        */
        private static double Distance(Ball first, Ball second)
        {
            int xDifference = first._center.X - second._center.X;   //x difference between balls
            int yDifference = first._center.Y - second._center.Y;   //y difference between bballs
                
            return Math.Abs(Math.Sqrt( (xDifference * xDifference) + (yDifference * yDifference) ));    //returns the double and absolute difference between the center of two supplied arguments
        }

        public override bool Equals(object? obj)
        {
            //detects if a ball overlaps another 
            if (obj is Ball other)
            {
                double distance = Distance(this, other);

                return distance < (_radius + other._radius); //if distance is less than the combined radius, it is true
            }
            //otherwise return false
            return false;
        }

    }
}
