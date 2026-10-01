using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GDIDrawer;
using System.Drawing;
using System.Numerics;

namespace jemuelG_ICA03_Static_Balls_of_Fun
{
    internal class Ball
    {

        private static Random _rand = new Random(); //set static field random value 
        private static CDrawer _drawer = null;      //set static field Cdrawer, set to null
        private static int _radius;                 //static int radius

        //static public property with get and set
        public static int Radius
        {
            get => _radius;     //same as return _radius, takes the value radius

            //sets the radius
            set 
            {
                int r = Math.Abs(value);        //makes sure the radius is positive

                //if statement so that the radius cannot be zero
                if (r == 0 || _drawer == null)
                {
                    return;
                }

                int max = Math.Min(_drawer.m_ciWidth, _drawer.m_ciHeight) / 2;  
                _radius = Math.Min(r, max); //set radius more than half the smaller of the Cdrawer width or Height
            }
        }

        private Color _color;       //instance field Color
        private Vector2 _position;  //instance field 2d position
        private Vector2 _velocity;  //instance field 2d velocity
        private int _iAlive = 255;  //instance field int _iAlive set to 255

        //Calls upon or runs exactly once
        static Ball()
        {
            _drawer = new CDrawer(_rand.Next(500,701), _rand.Next(600,801), bContinuousUpdate:false);   //Set Drawer size
            Radius = _rand.Next(10, 81);                                                                //set random predetermind radius
        }

        /* Method:     public Ball()
        * Purpose:     Default Constructor vor ball(), set and initialize values
        * Paramaters:  nothing
        * Returns:     nothing
        */
        public Ball()
        {
            _color = RandColor.GetColor();  //set color

            _velocity = new Vector2((float)(_rand.NextDouble() * 20.0 - 10.0), (float)(_rand.NextDouble() * 20.0 - 10.0));  //set random velocity

            _position = new Vector2(_rand.Next(Radius, _drawer.m_ciWidth-Radius), _rand.Next(Radius, _drawer.m_ciHeight - Radius)); //set random location
        }

        //Static manual property setting drawer position
        public static Point DrawerLocation
        {
            set
            {
                //check if drawer exists
                if (_drawer != null)
                {
                    _drawer.Position = value;
                }
            }
        }
        /* Method:     public void ShowBall()
        * Purpose:     use addCenterered ellipse to the drawer with a random location, use _iAlive member as the opacity and static radius
        * Paramaters:  nothing
        * Returns:     nothing
        */
        public void ShowBall()
        {
            Color c = Color.FromArgb(_iAlive, _color);
            _drawer.AddCenteredEllipse((int)_position.X, (int)_position.Y, Radius * 2, Radius * 2, c);
        }

        /* Method:     public void MoveBall()
        * Purpose:     Move ball to its new location and determine the borders to where the balls off from,
        *              also apply a decrement that causes "reincarnation" in the balls
        * Paramaters:  nothing
        * Returns:     nothing
        */
        public void MoveBall()
        {
            _iAlive--;          //_iAlive reperesents the opacity, effectyliuvely showing the ball "dying"

            //Revives the Ball to a random opacity and random position
            if(_iAlive < 1)
            {
                _position = new Vector2(_rand.Next(Radius, _drawer.m_ciWidth - Radius), _rand.Next(Radius, _drawer.m_ciHeight - Radius));
                _iAlive = _rand.Next(50, 128);
            }

            _position += _velocity;


            //if statements below checks the borders so that the position of the ball does not go out of bounds

            //checks left
            if(_position.X < Radius)
            {
                _position.X = Radius;
                _velocity.X *= -1;      //changes to the opposite direction
            }

            //checks right
            if (_position.X > _drawer.m_ciWidth - Radius)
            {
                _position.X = _drawer.m_ciWidth - Radius;
                _velocity.X *= -1;                          //changes to the opposite direction
            }

            //checks the top
            if (_position.Y < Radius)
            {
                _position.Y = Radius;
                _velocity.Y *= -1;
            }

            //checks the bottom
            if (_position.Y > _drawer.m_ciHeight - Radius)
            {
                _position.Y = _drawer.m_ciHeight - Radius;
                _velocity.Y *= -1;
            }
        }
        //static manual property Loading with no  get, just set
        public static bool Loading
        {
            set
            {
                //determine if value is true or false
                if (value)
                {
                    _drawer.Clear();    //clear drawer
                }
                else
                {
                    _drawer.Render();   //Renders Drawer
                }
            }
        }
    }
}
