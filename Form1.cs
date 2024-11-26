using System;
using System.Drawing;
using System.Windows.Forms;

namespace HW.Flag
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            int flagWidth = 600;
            int flagHeight = 400;

            int startX = 100;
            int startY = 50;

            g.FillRectangle(Brushes.White, startX, startY, flagWidth, flagHeight);

            int stripeHeight = flagHeight / 13;
            for (int i = 0; i < 13; i++)
            {
                if (i % 2 == 0) 
                {
                    g.FillRectangle(Brushes.Red, startX, startY + i * stripeHeight, flagWidth, stripeHeight);
                }
            }

            int blueWidth = flagWidth * 2 / 5;
            int blueHeight = stripeHeight * 7;
            g.FillRectangle(Brushes.Blue, startX, startY, blueWidth, blueHeight);

            int starsRows = 9; 
            int starsCols = 11; 
            float starRadius = 10; 
            float hGap = blueWidth / (starsCols + 1); 
            float vGap = blueHeight / (starsRows + 1); 

            for (int row = 0; row < starsRows; row++)
            {
                for (int col = 0; col < starsCols; col++)
                {
                    if ((row % 2 == 0 && col % 2 == 1) || (row % 2 == 1 && col % 2 == 0))
                        continue;

                    float x = startX + hGap * (col + 1);
                    float y = startY + vGap * (row + 1);

                    DrawStar(g, Brushes.White, x, y, starRadius);
                }
            }
        }

        private void DrawStar(Graphics g, Brush brush, float x, float y, float radius)
        {
            int numPoints = 10;

            PointF[] points = new PointF[numPoints];

            for (int i = 0; i < numPoints; i++)
            {
                double angle = i * Math.PI / 5 - Math.PI / 2;

                float r = (i % 2 == 0) ? radius : radius / 2;

                points[i] = new PointF(
                    x + r * (float)Math.Cos(angle),
                    y + r * (float)Math.Sin(angle));
            }

            g.FillPolygon(brush, points);
        }
    }
}
