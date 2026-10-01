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

        public void AddBall()
        {
            _drawer.AddCenteredEllipse(_center.X, _center.Y, _radius * 2, _radius * 2, _color);
        }

        public static bool Loading
        {
            set
            {
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

        public static Point DrawerPosition
        {
            set
            {
                _drawer.Position = value;
            }
        }

        private static double Distance(Ball first, Ball second)
        {
            int xDifference = first._center.X - second._center.X;
            int yDifference = first._center.Y - second._center.Y;

            return Math.Abs(Math.Sqrt(
                (xDifference * xDifference) +
                (yDifference * yDifference)
            ));
        }

        public override bool Equals(object? obj)
        {
            if (obj is Ball other)
            {
                double distance = Distance(this, other);

                return distance < (_radius + other._radius);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return 1;
        }
    }
}
