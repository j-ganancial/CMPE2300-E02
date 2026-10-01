/* Program: ICA03 - Static Balls of Fun
 * Description - implement a simple class including of some static methods and a static constructor to act as helpers
 * Date:    Oct 1, 2026
 * Author:  Jemuel G.
 * Course:  CMPE2300 - Object Based Programming
 * Class:   E02
 */


using System.Threading;
using jemuelG_ICA03_Static_Balls_of_Fun;

namespace jemuelG_ICA03_Static_Balls_of_Fun
{
    public partial class Form1 : Form
    {
        private List<Ball> balls = new List<Ball>();    //List of Balls
        private Thread _thread;                         //Thread
        private object _key = new object();             //Object _key data synchronization/marshaling
        public Form1()
        {
            InitializeComponent();

            //drawer location to the right of the form
            Ball.DrawerLocation = new System.Drawing.Point(this.Right + this.Right/2, this.Top);    

            MouseWheel += Form1_MouseWheel; //Manual added in Mousewheel
            KeyDown += Form1_KeyDown;       //Bind Keydown

            _thread = new Thread(ThreadLoop);   // call thread
            _thread.IsBackground = true;        // enable as background thread
            _thread.Start();                    //Start thread
        }

        private void Form1_MouseWheel(object? sender, MouseEventArgs e)
        {
            Ball.Radius += e.Delta / 10;        //Make The radius equal to the e.Delta via scrollwheel
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            //Makes sure the thread is executed one thread at a time
            lock (_key)
            {
                //detect if key Add is pressed
                if(e.KeyCode == Keys.A)
                {
                    //adds 5 balls
                    for(int i = 0; i < 5; i++)
                    {
                        balls.Add(new Ball());
                    }
                }
                //detect if key subtract is pressed
                else if (e.KeyCode == Keys.S)
                {
                    //clears the ball
                    balls.Clear();
                }
            }

        }

        /* Method:      private void ThreadLoop()
         * Purpose:     ThreadLoop continuously running in the background, suspends thread at 25 ms
         * Paramaters:  nothing
         * Returns:     nothing
         */
        private void ThreadLoop()
        {
            //infinite while loop
            while(true)
            {
                //Makes sure the thread is executed one thread at a time
                lock (_key)
                {
                    //Overall clears and renders the balls

                    Ball.Loading = true;    //indicates loading is true

                    //goes through each ball and "animates the ball" continuously
                    foreach (Ball b in balls)
                    {
                        b.MoveBall();   //Call upon Moveball method
                        b.ShowBall();   //Call upon ShowBall method
                    }

                    Ball.Loading = false;   //Loading is false
                }
                Thread.Sleep(25);   //suspends thread to 25 milliseconds
            }

        }
    }
}
