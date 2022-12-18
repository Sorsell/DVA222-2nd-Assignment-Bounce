//BEGIN_CUT
#define SOLUTION_ENABLED
//END_CUT
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using Bouncing_Balls;

namespace BouncingBalls
{
	public class Engine : Form1
	{
		private Random rnd = new Random();

		private readonly int NBalls = 45;
		private readonly int NBoxes = 2;
		private readonly int NLines= 4;

		private HashSet<Ball> Balls = new HashSet<Ball>();
		private HashSet<Box> Boxes = new HashSet<Box>();
		private HashSet<Line> Lines = new HashSet<Line>();

		// Update the ball's position, bouncing if necessary.
		override protected void tmrMoveBall_Tick(object sender, EventArgs e)
		{
			//Adds Redbox
			if (Boxes.Count < NBoxes) 
			{
				int height = 100;
				int width = 75;
                PointF C = new PointF(400,300);

				Boxes.Add(new Box(C,width,height,0));
			}
            //Adds "Bluebox"
            if (Boxes.Count < NBoxes)
            {
                int height = 75;
                int width = 150;
                PointF C = new PointF(100, 85);

                Boxes.Add(new Box(C, width, height,1));
            }

			//Adds Green Line1
			if (Lines.Count < NLines)
			{
				int length = 300;
				PointF C = new PointF(135, 70);

				Lines.Add(new Line(C, length, 2));
			}

            //Adds Green Line2
            if (Lines.Count < NLines)
            {
                int length = 250;
                PointF C = new PointF(260, 490);

                Lines.Add(new Line(C, length, 2));
            }

            //Adds Yellow Line1
            if (Lines.Count < NLines)
            {
                int length = 210;
                PointF C = new PointF(70, 145);

                Lines.Add(new Line(C, length, 3));
            }

            //Adds Yellow Line2
            if (Lines.Count < NLines)
            {
                int length = 200;
                PointF C = new PointF(530, 220);

                Lines.Add(new Line(C, length, 3));
            }

            //Add one ball if they are less than NBalls
            if (Balls.Count < NBalls && rnd.Next(20) == 0)
			{
				double Angle = rnd.NextDouble() * Math.PI * 2.0;
				PointF Center = new PointF(ClientSize.Width / 2, ClientSize.Height / 2);
				Balls.Add(new Ball(Center, 5.0f, Angle));
			}

			foreach (var ball in Balls)
			{
				ball.Move();
				foreach (var box in Boxes)
				{
					box.IsInside(ball);
				}
				foreach (var line in Lines)
				{
					line.IsBeside(ball);
				}
			}

			//Remove balls out of the scene
			Balls.RemoveWhere(ball =>
				ball.Position.X < -ball.Radius ||
				ball.Position.X > ClientSize.Width + ball.Radius ||
				ball.Position.Y < -ball.Radius ||
				ball.Position.Y > ClientSize.Height + ball.Radius);

			Refresh();
		}

		// Draw the ball at its current location.
		override protected void Form1_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			e.Graphics.Clear(BackColor);
			foreach (var ball in Balls)
			{
				ball.Draw(e.Graphics);
			}
			foreach (var box in Boxes)
			{
				box.Draw(e.Graphics);
			}
			foreach (var line in Lines)
			{
				line.Draw(e.Graphics);
			}

		}
	}
}
