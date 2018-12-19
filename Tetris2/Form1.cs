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
            TestGrid();

            //all the squares are empty
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 18; j++)
                {
                    squareOrigin[i, j] = new PointF(51 + i * 21, 51 + j * 21);
                    squareEmpty[i, j] = true;
                }
            }

            Shape(squareOrigin[startPosition.X, startPosition.Y], 't', pos);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                startPosition.Y++;
                Shape(squareOrigin[startPosition.X, startPosition.Y], 't', pos);
            }
            else if (e.KeyCode == Keys.Left)
            {
                startPosition.X--;
                Shape(squareOrigin[startPosition.X, startPosition.Y], 't', pos);
            }
            else if (e.KeyCode == Keys.Right)
            {
                startPosition.X++;
                Shape(squareOrigin[startPosition.X, startPosition.Y], 't', pos);
            }
            else if (e.KeyCode == Keys.Up)
            {
                pos = (pos + 1) % 4;
                Shape(squareOrigin[startPosition.X, startPosition.Y], 't', pos);
            }
        }

        public void Shape(PointF origin, char shape, int position)
        {
            TestGrid();
            if (shape == 't')
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
        }

        public void TestGrid()
        {
            grid.Clear(Color.WhiteSmoke);
            /*
            for (int i = 50; i <= 260; i += 21)
            {
                grid.DrawLine(gridPen, i, 50, i, 428);
            }

            for (int i = 50; i <= 428; i += 21)
            {
                grid.DrawLine(gridPen, 50, i, 260, i);
            }
            //*/
        }

        public bool CollisionCheck(PointF origin, char shape, int position)
        {

            //outside boundaries
            try { }
            catch { }

            //touching another piece  

            return false;
        }

    }
}
