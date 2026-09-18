/* Program: ICA01 - TrekLight
 * Description - create a class that behaves like one of the informational
                    lights seen on Star Trek: The Original Series
 * Date:    September 17, 2026
 * Author:  Jemuel G.
 * Course:  CMPE2300 - Object Based Programming
 * Class:   E02
 * Submission code: 1241_2300_A01
 */
using GDIDrawer;
using System.IO;

namespace ICA01_TrekLight
{
    public partial class Form1 : Form
    {
        private TrekLight[] _lights = null;     //Array of _lights, initially null
        private CDrawer _drawer = null;         //Cdrawer member initialiozed to null
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();   //Timer initialized
        private Random _rand = new Random();    //Random object
        public Form1()
        {
            InitializeComponent();

            // Timer setup
            _timer.Interval = 80;
            _timer.Enabled = true;
            _timer.Tick += UI_TImer_Tick;

            // Form events
            Shown += Form1_Shown;
            KeyDown += Form1_KeyDown;
        }

        private void Form1_Shown(object? sender, EventArgs e)
        {
            _drawer = new CDrawer(800, 500);    //set Drawing window to

            _drawer.ContinuousUpdate = false;
            _drawer.Scale = 50;

            int numLights = _drawer.ScaledWidth * _drawer.ScaledHeight;

            _lights = new TrekLight[numLights];

            _drawer.Position = new Point(
                Location.X + Width,
                Location.Y
            );

            Activate();
        }

        private void UI_TImer_Tick(object? sender, EventArgs e)
        {
            _drawer.Clear();
            for (int i = 0; i < _lights.Length; i++)
            {
                if (_lights[i] != null)
                {
                    _lights[i].Tick();
                    _lights[i].RenderLight(_drawer, i);
                }
            }

            _drawer.Render();
        }

        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (_lights == null)
                return;
            switch (e.KeyCode)
            {
                case Keys.D1:

                    int half = _lights.Length / 2;

                    // First half - default constructor
                    for (int i = 0; i < half; i++)
                    {
                        _lights[i] = new TrekLight();
                    }

                    // Second half - custom constructor
                    for (int i = half; i < _lights.Length; i++)
                    {
                        byte onValue = (byte)_rand.Next(50, 201);

                        _lights[i] = new TrekLight(
                            RandColor.GetColor(),
                            onValue,
                            4
                        );
                    }
                    break;
                case Keys.D2:
                    for (int i = 0; i < _lights.Length; i++)
                    {
                        if (_lights[i] == null)
                        {
                            _lights[i] = new TrekLight();
                        }
                    }
                    break;
                case Keys.D3:
                    for (int i = _lights.Length - 1; i >= 0; i--)
                    {
                        if (_lights[i] == null)
                        {
                            _lights[i] = new TrekLight();
                            break;
                        }
                    }
                    break;
                case Keys.D4:
                    for (int i = _lights.Length - 1; i >= 0; i--)
                    {
                        if (_lights[i] != null)
                        {
                            _lights[i] = null;
                            break;
                        }
                    }
                    break;
                case Keys.D5:
                    while (true)
                    {
                        int index = _rand.Next(_lights.Length);

                        if (_lights[index] != null)
                        {
                            byte onValue = (byte)_rand.Next(50, 201);

                            _lights[index] = new TrekLight(
                                RandColor.GetColor(),
                                onValue,
                                4
                            );

                            break;
                        }
                    }
                    break;
                case Keys.Enter:
                    foreach (TrekLight light in _lights)
                    {
                        light?.RedAlert();
                    }
                    break;
            }

        }


    }
}
