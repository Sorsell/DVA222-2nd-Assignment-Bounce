using BouncingBalls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace Bouncing_Balls
 
{
    class Box : Shape
    {
        int color; 
        float width;
        float height;
        

        //constructor
        public Box(PointF Position, float width, float height,int color) : base(Position)
        {
            this.width = width;
            this.height = height;
            this.color = color;
        }
        public void IsInside(Ball ball)
        {
            //if the ball is inside the box
            if (ball.Position.X > Position.X && ball.Position.X < Position.X + width && ball.Position.Y > Position.Y && ball.Position.Y < Position.Y + height)
            {
                //if the box is red
                if (color == 0)
                {
                    //increase speed 2%
                    ball.Speed.X += ball.Speed.X * 0.02f;
                    ball.Speed.Y += ball.Speed.Y * 0.02f;
                }
                //if the box is blue
                else
                {
                    //decrease speed 1%
                    ball.Speed.X -= ball.Speed.X * 0.01f;
                    ball.Speed.Y -= ball.Speed.Y * 0.01f;
                }
            }
        }
        //override method Draw
        public override void Draw(Graphics g)
        {
            if (color == 0)
            {
                g.DrawRectangle(Pens.Red, Position.X, Position.Y, width, height);
            }
            else
            {
                g.DrawRectangle(Pens.Blue, Position.X, Position.Y, width, height);
            }
        }
    }
}
