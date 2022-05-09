using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dodgeGame
{
    public partial class Form1 : Form
    {
        Rectangle hero = new Rectangle(0, 200, 15, 15);

        int heroSpeed = 5;
        int obstacleLeftSpeed = 8;
        int obstacleRighttSpeed = 8;

        List<Rectangle> obstacleLeft = new List<Rectangle>();
        List<Rectangle> obstacleRight = new List<Rectangle>();

        bool leftDown = false;
        bool rightDown = false;
        bool upDown = false;
        bool downDown = false;

        SolidBrush violetBrush = new SolidBrush(Color.Violet);
        SolidBrush blueBrush = new SolidBrush(Color.SkyBlue);

        int counterL = 0;
        int counterR = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.Down:
                    downDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.Down:
                    downDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //counterR++;
            //if (counterR == 5)
            //{
            //    obsticles.Add(new Rectangle(100, 0, 10, 50));
            //    counter = 0;
            //}

            //move player 1 
            if (upDown == true && hero.Y > 0)
            {
                hero.Y -= heroSpeed;
            }

            if (downDown == true && hero.Y < this.Height - hero.Height)
            {
                hero.Y += heroSpeed;
            }

            if (leftDown == true && hero.X > 0)
            {
                hero.X -= heroSpeed;
            }

            if (rightDown == true && hero.Y < this.Width - hero.Width)
            {
                hero.X += heroSpeed;
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(violetBrush, hero);
        }
    }
}
