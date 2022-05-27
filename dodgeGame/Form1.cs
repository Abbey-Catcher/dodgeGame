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
        Rectangle hero = new Rectangle(0, 170, 15, 15);

        int heroSpeed = 5;
        int obstacleLeftSpeed = 8;
        int obstacleRightSpeed = -8;

        List<Rectangle> obstacleLeft = new List<Rectangle>();
        List<Rectangle> obstacleRight = new List<Rectangle>();

        bool leftDown = false;
        bool rightDown = false;
        bool upDown = false;
        bool downDown = false;

        SolidBrush violetBrush = new SolidBrush(Color.Violet);
        SolidBrush blueBrush = new SolidBrush(Color.SkyBlue);

        int counter = 0;
        string gameState = "waiting";

        public Form1()
        {
            InitializeComponent();
        }

        public void GameInitialize()
        {
            gameTimer.Enabled = true;
            gameState = "running";
            obstacleLeft.Clear();
            obstacleRight.Clear();

            hero.X = this.Width / 2 - hero.Width / 2;
            hero.Y = this.Height - groundHeight - hero.Height;
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
            //move player
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

            //new y
            for (int i = 0; i < obstacleLeft.Count; i++)
            {
                int y = obstacleLeft[i].Y + obstacleLeftSpeed;

                obstacleLeft[i] = new Rectangle(obstacleLeft[i].X, y, 10, 50);
            }

            //new y
            for (int i = 0; i < obstacleRight.Count; i++)
            {
                int y = obstacleRight[i].Y + obstacleRightSpeed;

                obstacleRight[i] = new Rectangle(obstacleRight[i].X, y, 10, 50);
            }

            //add new
            counter++;
            if (counter == 15)
            {
                obstacleLeft.Add(new Rectangle(150, 0, 10, 50));
                obstacleRight.Add(new Rectangle(400, this.Width, 10, 50));
                counter = 0;
            }

            //hero interacts, end
            for (int i = 0; i < obstacleLeft.Count; i++)
            {
                if (hero.IntersectsWith(obstacleLeft[i]))
                {
                    gameTimer.Enabled = false;
                }
            }

            //hero interacts, end
            for (int i = 0; i < obstacleRight.Count; i++)
            {
                if (hero.IntersectsWith(obstacleRight[i]))
                {
                    gameTimer.Enabled = false;
                }
            }

            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "running")
            {
                e.Graphics.FillRectangle(violetBrush, hero);
            }

            for (int i = 0; i < obstacleLeft.Count(); i++)
            {
                e.Graphics.FillRectangle(blueBrush, obstacleLeft[i]);
                e.Graphics.FillRectangle(blueBrush, obstacleRight[i]);
            }
        }
    }
}
