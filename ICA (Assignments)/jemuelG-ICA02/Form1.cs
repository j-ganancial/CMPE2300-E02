/* Program: ICA02 -  Bouncy Properties
 * Description - implement a simple class representing a bouncy Ball.
 * Date:    Sept 24, 2026
 * Author:  Jemuel G.
 * Course:  CMPE2300 - Object Based Programming
 * Class:   E02
 */

using GDIDrawer;
using jemuelG_ICA02_Bouncy;

namespace jemuelG_ICA02_Bouncy
{
    public partial class Form1 : Form
    {
        CDrawer drawer;                         //Cdrawer
        List<Ball> _balls = new List<Ball>();   //List of balls
        System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();   //Timer
        int _radius = 50;    //radius of the ball
        int _opacity = 128;   //opacity of the ball


        public Form1()
        {
            drawer = new CDrawer(bContinuousUpdate: false);  //Cdrawer default size and set continuousupdate false

            _timer.Tick += UI_Timer_Tick;           //Bind timer

            InitializeComponent();

            //Manually put in the mouswheel evet handler for the form
            UI_Opacity_Lbl.MouseWheel += UI_Opacity_Lbl_MouseWheel1;
            UI_Radius_Lbl.MouseWheel += UI_Radius_Lbl_MouseWheel1;
        }

        private void UI_Timer_Tick(object? sender, EventArgs e)
        {
            //if statement to determine location x,y for left click
            if (drawer.GetLastMouseLeftClick(out Point p))
            {
                _balls.Add(new Ball(p));    //add to list and call upon Ball() constructor
            }

            //if statement to determine wheter to clear the drawer when right clicked
            if(drawer.GetLastMouseRightClick(out Point c))
            {
                _balls.Clear(); //clear ball
            }

            drawer.Clear(); //clear drawer

            //iterate through list 
            foreach(Ball b in _balls)
            {
                b.MoveBall(drawer); //invokes moveball
                b.ShowBall(drawer); //invokes showball
            }

            drawer.Render();    //Render Cdrawer to display

            //if statement to determine if there balls active in the drawer
            if(_balls.Count > 0) //&& UI_All_checkBox.Checked)
            {
                UI_TxtBox_All.Text = _balls[^1].ToString(); //Calls Last Element and displays to textbox in the form design
            }
        }
        private void UI_Radius_Lbl_MouseWheel1(object? sender, MouseEventArgs e)
        {
            //if statements to determine if delta is negative or positive (mousewheel turn)
            if (e.Delta < 0)
            {
                _radius -= 1;
            }
            else
            {
                _radius += 1;
            }

            UI_Radius_TxtBox.Text = _radius.ToString(); //display radius to the txtbox as the wheel turns

            if (_balls.Count == 0) return;              //determine if there are ay balls and exits if there are none

            //check if all is checked which changes radius to all balls, otherwise only change the last ball inputted
            if (UI_All_checkBox.Checked)
            {
                foreach (Ball b in _balls)//Goes through every ball and set radius
                {
                    b.Radius = _radius;
                }
            }
            else
            {
                _balls[^1].Radius = _radius;    //gets the last ball info
            }
        }

        private void UI_Opacity_Lbl_MouseWheel1(object? sender, MouseEventArgs e)
        {
            //if statements to determine if delta is negative or positive (mousewheel turn)
            if (e.Delta < 0)
            {
                _opacity -= 10;
            }
            else
            {
                _opacity += 10;
            }

            UI_Opacity_TxtBox.Text = _opacity.ToString();   //display opacity to the txtbox as the wheel turns

            if (_balls.Count == 0) return;                  //determine if there are ay balls and exits if there are none

            //check if all is checked which changes opacity to all balls, otherwise only change the last ball inputted
            if (UI_All_checkBox.Checked)
            {
                foreach (Ball b in _balls)//Goes through every ball and set opacity
                {
                    b.Opacity = _opacity;
                }
            }
            else
            {
                _balls[^1].Opacity = _opacity;
            }
        }


    }
}
