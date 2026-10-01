/* Program: ICA04 - Don’t Be Touching My Balls
 * Description -  implement a simple class implementing an Equals() to ensure balls
don’t overlap.
 * Date:    Oct 1, 2026
 * Author:  Jemuel G.
 * Course:  CMPE2300 - Object Based Programming
 * Class:   A01
 */

using System;
using System.Collections.Generic;
using System.Drawing;

namespace jemuelG_ICA04
{
    public partial class Form1 : Form
    {
        private List<Ball> _balls = new List<Ball>();
        private int _ballRadius = 25;

        private const int addCount = 25;
        private const int discardLimit = 1000;
        public Form1()
        {
            InitializeComponent();

            Ball.DrawerPosition =
               new Point(this.Right + this.Right / 2, this.Top);

            UI_AddBalls_Btn.Text = $"Add Balls : Radius = {_ballRadius}";


            UI_AddBalls_Btn.MouseWheel += UI_AddBalls_Btn_MouseWheel;
            UI_AddBalls_Btn.MouseDown += UI_AddBalls_Btn_MouseDown;
        }


        private void UI_AddBalls_Btn_MouseWheel(object? sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                _ballRadius += 5;
            }
            else
            {
                _ballRadius -= 5;
            }

            if (_ballRadius < 1)
            {
                _ballRadius = 1;
            }

            UI_AddBalls_Btn.Text = $"Add Balls: Radius = {_ballRadius}";
        }

        private void UI_AddBalls_Btn_MouseDown(object sender, MouseEventArgs e)
        {
            int added = 0;
            int discarded = 0;

            UI_ProgressBar.Value = 0;

            Ball.Loading = true;

            while (added < addCount && discarded < discardLimit)
            {
                Ball newBall = new Ball(_ballRadius);

                bool touching = _balls.Contains(newBall);

                bool addBall = false;

                if ((_balls.Count == 0) ||
                    (e.Button == MouseButtons.Left && !touching) ||
                    (e.Button == MouseButtons.Right && touching))
                {
                    addBall = true;
                }

                if (addBall == true)
                {
                    _balls.Add(newBall);
                    added++;
                }
                else
                {
                    discarded++;
                }
            }

            foreach (Ball b in _balls)
            {
                b.AddBall();

                UI_ProgressBar.Value = discarded;
            }

            Ball.Loading = false;

            this.Text = $"Add Balls: {_balls.Count} Balls discarded {discarded}";
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                _balls.Clear();

                Ball.Loading = true;
                Ball.Loading = false;

                UI_AddBalls_Btn.Text = $"Add Balls: Radius = {_ballRadius}";

                this.Text = "Add Balls: 0";
            }
        }
    }
}
