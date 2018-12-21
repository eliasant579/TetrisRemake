using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tetris2
{
    public partial class Form1 : Form
    {
        Graphics grid;
        Pen gridPen = new Pen(Color.Black);
        SolidBrush tBrush = new SolidBrush(Color.Red);
        Random shapeRand = new Random();

        //select first shape
        //call next shape

        //this stuff is restored only when a new piece is placed
        Point startPosition = new Point(4, 0);
        int pos = 0;
        int fallCounter = 0;
        int levelFreq = 10;

        //once only
        Point[,] squareOrigin = new Point[10, 18];

        //keys pressed
        Boolean leftArrowDown, downArrowDown, rightArrowDown, upArrowDown;

        //not sure if this sould be bigger by one on each side, it might be easier to check collisions
        bool[,] squareEmpty = new bool[10, 18];

        public Form1()
        {
            InitializeComponent();

            grid = this.CreateGraphics();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Refresh();

            //all the squares are empty
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    squareOrigin[i, j] = new Point(51 + i * 21, 51 + j * 21);
                    squareEmpty[i, j] = true;
                }
            }

            ShapeDraw(squareOrigin[startPosition.X, startPosition.Y], 'T', pos);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                downArrowDown = true;
            }
            else if (e.KeyCode == Keys.Left)
            {
                leftArrowDown = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                rightArrowDown = true;
            }
            else if (e.KeyCode == Keys.Up)
            {
                upArrowDown = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                downArrowDown = false;
            }
            else if (e.KeyCode == Keys.Left)
            {
                leftArrowDown = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                rightArrowDown = false;
            }
            else if (e.KeyCode == Keys.Up)
            {
                upArrowDown = false;
            }
        }

        public char NextShapeSelect(char mainShape)
        {
            char shape = 'o';
            return shape;
        }

        private void movesTimer_Tick(object sender, EventArgs e)
        {
            if (upArrowDown == true)
            {
                pos = (pos + 1) % 4;
            }
            else if (leftArrowDown == true)
            {
                startPosition.X--;
            }
            else if (rightArrowDown == true)
            {
                startPosition.X++;
            }
            else if (downArrowDown == true)
            {
                startPosition.Y++;
            }

            fallCounter++;

            if (fallCounter == levelFreq)
            {
                startPosition.Y++;
                fallCounter = 0;
            }
            Refresh();
            ShapeDraw(squareOrigin[startPosition.X, startPosition.Y], 'T', pos);
        }

        public void ShapeDraw(Point origin, char shape, int position)
        {
            Refresh();
            switch (shape)
            {
                case 'T':
                    switch (position)
                    {
                        case 0:
                           //check for collisions than
                                squareEmpty[startPosition.X - 1, startPosition.Y] = false;
                                squareEmpty[startPosition.X, startPosition.Y] = false;
                                squareEmpty[startPosition.X + 1, startPosition.Y] = false;
                                squareEmpty[startPosition.X, startPosition.Y + 1] = false;

                                grid.FillRectangle(tBrush, origin.X - 21, origin.Y, 20, 20);
                                grid.FillRectangle(tBrush, origin.X, origin.Y, 20, 20);
                                grid.FillRectangle(tBrush, origin.X + 21, origin.Y, 20, 20);
                                grid.FillRectangle(tBrush, origin.X, origin.Y + 21, 20, 20);
                          break;
                        case 1:

                            try
                            {
                                squareEmpty[startPosition.X, startPosition.Y - 1] = false;
                                squareEmpty[startPosition.X, startPosition.Y] = false;
                                squareEmpty[startPosition.X, startPosition.Y + 1] = false;
                                squareEmpty[startPosition.X - 1, startPosition.Y] = false;

                                grid.FillRectangle(tBrush, origin.X, origin.Y - 21, 20, 20);
                                grid.FillRectangle(tBrush, origin.X, origin.Y, 20, 20);
                                grid.FillRectangle(tBrush, origin.X, origin.Y + 21, 20, 20);
                                grid.FillRectangle(tBrush, origin.X - 21, origin.Y, 20, 20);
                            }
                            catch { }

                            break;
                        case 2:

                            try
                            {
                                squareEmpty[startPosition.X, startPosition.Y - 1] = false;
                                squareEmpty[startPosition.X, startPosition.Y] = false;
                                squareEmpty[startPosition.X + 1, startPosition.Y] = false;
                                squareEmpty[startPosition.X, startPosition.Y - 1] = false;

                                grid.FillRectangle(tBrush, origin.X, origin.Y - 21, 20, 20);
                                grid.FillRectangle(tBrush, origin.X, origin.Y, 20, 20);
                                grid.FillRectangle(tBrush, origin.X + 21, origin.Y, 20, 20);
                                grid.FillRectangle(tBrush, origin.X - 21, origin.Y, 20, 20);
                            }
                            catch { }

                            break;
                        case 3:

                            try
                            {
                                squareEmpty[startPosition.X, startPosition.Y - 1] = false;
                                squareEmpty[startPosition.X, startPosition.Y] = false;
                                squareEmpty[startPosition.X + 1, startPosition.Y] = false;
                                squareEmpty[startPosition.X, startPosition.Y + 1] = false;

                                grid.FillRectangle(tBrush, origin.X, origin.Y - 21, 20, 20);
                                grid.FillRectangle(tBrush, origin.X, origin.Y, 20, 20);
                                grid.FillRectangle(tBrush, origin.X + 21, origin.Y, 20, 20);
                                grid.FillRectangle(tBrush, origin.X, origin.Y + 21, 20, 20);
                            }
                            catch { }

                            break;
                    }
                    break;
                case 'S':
                    switch (position)
                    {
                        case 0:
                            grid.FillRectangle(tBrush, origin.X, origin.Y, 20, 20);
                            grid.FillRectangle(tBrush, origin.X + 21, origin.Y, 20, 20);
                            grid.FillRectangle(tBrush, origin.X, origin.Y + 21, 20, 20);
                            grid.FillRectangle(tBrush, origin.X - 21, origin.Y + 21, 20, 20);
                            break;
                        case 1:
                            grid.FillRectangle(tBrush, origin.X, origin.Y, 20, 20);
                            grid.FillRectangle(tBrush, origin.X, origin.Y - 21, 20, 20);
                            grid.FillRectangle(tBrush, origin.X + 21, origin.Y, 20, 20);
                            grid.FillRectangle(tBrush, origin.X + 21, origin.Y + 21, 20, 20);
                            break;
                        case 2:
                            goto case 0;
                        case 3:
                            goto case 1;
                    }
                    break;
                case 'Z':
                    switch (position)
                    {
                        case 0:
                            grid.FillRectangle(tBrush, origin.X, origin.Y, 20, 20);
                            grid.FillRectangle(tBrush, origin.X - 21, origin.Y, 20, 20);
                            grid.FillRectangle(tBrush, origin.X, origin.Y + 21, 20, 20);
                            grid.FillRectangle(tBrush, origin.X + 21, origin.Y + 21, 20, 20);
                            break;
                        case 1:
                            grid.FillRectangle(tBrush, origin.X, origin.Y, 20, 20);
                            grid.FillRectangle(tBrush, origin.X, origin.Y - 21, 20, 20);
                            grid.FillRectangle(tBrush, origin.X - 21, origin.Y, 20, 20);
                            grid.FillRectangle(tBrush, origin.X - 21, origin.Y + 21, 20, 20);
                            break;
                        case 2:
                            goto case 0;
                        case 3:
                            goto case 1;
                    }
                    break;
                case 'I':
                    switch (position)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            goto case 0;
                        case 3:
                            goto case 1;
                    }
                    break;
                case 'L':
                    switch (position)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                    }
                    break;
                case 'J':
                    switch (position)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                    }
                    break;
            }
        }

        public bool CollisionCheck(Point origin, char shape, int position)
        {

            //outside boundaries
            try { }
            catch { }

            //touching another piece  

            return false;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //*/
            for (int i = 50; i <= 260; i += 21)
            {
                e.Graphics.DrawLine(gridPen, i, 50, i, 428);
            }

            for (int i = 50; i <= 428; i += 21)
            {
                e.Graphics.DrawLine(gridPen, 50, i, 260, i);
            }
            //*/
        }
    }
}
