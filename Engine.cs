//BEGIN_CUT
#define SOLUTION_ENABLED
//END_CUT
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BouncingBalls
{
	public class Engine : Form1
	{
		private Random rnd = new Random();

		private readonly int NBalls = 45;

		private HashSet<Ball> Balls = new HashSet<Ball>();

		// Update the ball's position, bouncing if necessary.
		override protected void tmrMoveBall_Tick(object sender, EventArgs e)
		{

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
		}
	}
}
