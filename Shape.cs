using System;
using System.Drawing;

namespace BouncingBalls
{

	public abstract class Shape
	{
		protected PointF position;

		public PointF Position
		{
			get { return position; }
			set { position = value; }
		}

		public Shape(PointF position)
		{
			this.position = position;
		}

		public abstract void Draw(Graphics g);
	}

}
