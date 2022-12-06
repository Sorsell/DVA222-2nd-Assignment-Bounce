using System;
using System.Drawing;

namespace BouncingBalls
{

	public class Vector2D
	{
		public float X { get; set; }
		public float Y { get; set; }

		public float Length { get { return (float)Math.Sqrt(X * X + Y * Y); } }

		public Vector2D(float X, float Y)
		{
			this.X = X;
			this.Y = Y;
		}

		public static Vector2D operator *(Vector2D vector, float scalar)
		{
			return new Vector2D(vector.X * scalar, vector.Y * scalar);
		}

		public static PointF operator +(PointF point, Vector2D vector)
		{
			return new PointF(point.X + vector.X, point.Y + vector.Y);
		}
	}

}
