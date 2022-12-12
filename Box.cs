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
