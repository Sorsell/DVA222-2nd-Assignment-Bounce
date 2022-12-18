using BouncingBalls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bouncing_Balls

{
    class Line : Shape
    {
        int color;
        float length;

        //constructor
        public Line(PointF Position, float length, int color) : base(Position)
        {
            this.length = length;
            this.color = color;
        }

        public void IsBeside(Ball ball)
        {
            if (ball.Position.X + ball.Radius > Position.X && ball.Position.X + ball.Radius < Position.X + length && ball.Position.Y < Position.Y + ball.Radius && ball.Position.Y + ball.Radius > Position.Y)
            {
                if (color == 2)
                {
                    ball.Speed.Y = -ball.Speed.Y;
                }
            }

            if (ball.Position.Y + ball.Radius > Position.Y && ball.Position.Y + ball.Radius < Position.Y + length && ball.Position.X < Position.X + ball.Radius && ball.Position.X + ball.Radius > Position.X)
            { 
                if (color == 3)
                {
                    ball.Speed.X = -ball.Speed.X;
                }
            }
        }

        public override void Draw(Graphics g)
        {
            if (color == 2)
                g.DrawLine(Pens.Green, Position.X, Position.Y, Position.X + length, Position.Y);
            
            if (color == 3)
                g.DrawLine(Pens.Yellow, Position.X, Position.Y, Position.X, Position.Y + length);
        }
    }
}