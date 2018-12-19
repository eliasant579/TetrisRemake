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

        //is restored only when a new piece is placed
        Point startPosition = new Point(4, 0);
        int pos = 0;

        PointF[,] squareOrigin = new PointF[10, 18];
        bool[,] squareEmpty = new bool[10, 18];

        public Form1()
        {
            InitializeComponent();

            grid = this.CreateGraphics();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

            //*
            //Grid for testing purposes only
            for (int i = 50; i <= 260; i += 21)
            {
                grid.DrawLine(gridPen, i, 50, i, 428);
            }

            for (int i = 50; i <= 428; i += 21)
            {
                grid.DrawLine(gridPen, 50, i, 260, i);
            }
            //*/

            //don't care if it's not one single loop

            //all the squares are empty
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    squareOrigin[i, j] = new PointF(51 + i * 21, 51 + j * 21);
                    squareEmpty[i, j] = true;
                }
            }

            TShape(squareOrigin[startPosition.X, startPosition.Y], pos);

            /* works
            //this will probably change to a shape method
            TShape(squareOrigin[5, 0], 1);
            TShape(squareOrigin[6, 4], 2);
            TShape(squareOrigin[7, 12], 3);
            TShape(squareOrigin[3, 4], 4);
            //*/
        }

        //using the origin point and 
        public bool CollisionCheck(PointF centre, string shape, int position)
        {

            //outside boundaries
            try { }
            catch { }

            //touching another piece  

            return false;
        }

        public void TShape(PointF origin, int position)
        {
            switch (position)
            {
                case 0:
                    grid.FillRectangle(tBrush, origin.X - 21, origin.Y, 20, 20);
                    grid.FillRectangle(tBrush, origin.X, origin.Y, 20, 20);
                    grid.FillRectangle(tBrush, origin.X + 21, origin.Y, 20, 20);
                    grid.FillRectangle(tBrush, origin.X, origin.Y + 21, 20, 20);
                    break;
                case 1:
                    grid.FillRectangle(tBrush, origin.X, origin.Y - 21, 20, 20);
                    grid.FillRectangle(tBrush, origin.X, origin.Y, 20, 20);
                    grid.FillRectangle(tBrush, origin.X, origin.Y + 21, 20, 20);
                    grid.FillRectangle(tBrush, origin.X - 21, origin.Y, 20, 20);
                    break;
                case 2:
                    grid.FillRectangle(tBrush, origin.X, origin.Y - 21, 20, 20);
                    grid.FillRectangle(tBrush, origin.X, origin.Y, 20, 20);
                    grid.FillRectangle(tBrush, origin.X + 21, origin.Y, 20, 20);
                    grid.FillRectangle(tBrush, origin.X - 21, origin.Y, 20, 20);
                    break;
                case 3:
                    grid.FillRectangle(tBrush, origin.X, origin.Y - 21, 20, 20);
                    grid.FillRectangle(tBrush, origin.X, origin.Y, 20, 20);
                    grid.FillRectangle(tBrush, origin.X + 21, origin.Y, 20, 20);
                    grid.FillRectangle(tBrush, origin.X, origin.Y + 21, 20, 20);
                    break;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                startPosition.Y++;
                TShape(squareOrigin[startPosition.X, startPosition.Y], pos);
            }
            else if (e.KeyCode == Keys.Left)
            {
                startPosition.X--;
                TShape(squareOrigin[startPosition.X, startPosition.Y], pos);
            }
            else if (e.KeyCode == Keys.Right)
            {
                startPosition.X++;
                TShape(squareOrigin[startPosition.X, startPosition.Y], pos);
            }
            else if (e.KeyCode == Keys.Up)
            {
                pos = (pos + 1) % 4;
                TShape(squareOrigin[startPosition.X, startPosition.Y], pos);
            }
        }
    }
}
