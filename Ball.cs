using System;
using System.Drawing;

namespace BouncingBalls
{

	public class Ball : Shape
	{

		public readonly float Radius;

		private Vector2D speed;

		private readonly float speedMax = 4.0f;
		private readonly float speedMin = 0.25f;

		public Vector2D Speed
		{
			get { return speed; }
			set { if (value.Length > speedMin && value.Length < speedMax) speed = value; }
		}

		public Ball(PointF Position, float Radius, double Angle) : base(Position)
		{
			this.Radius = Radius;
			this.Speed = new Vector2D((float)Math.Cos(Angle) * 1.5f, (float)Math.Sin(Angle) * 1.5f);
		}

		public void Move()
		{
			position += speed;
		}

		override public void Draw(Graphics g)
		{
			g.DrawEllipse(Pens.White, Position.X - Radius, Position.Y - Radius, 2.0f * Radius, 2.0f * Radius);
		}
	}

}
