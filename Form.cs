using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BouncingBalls
{

	public abstract class Form1 : Form
	{
		private System.ComponentModel.IContainer components = null;

		internal System.Windows.Forms.Timer tmrMoveBall;

		public Form1()
		{
			this.components = new System.ComponentModel.Container();
			this.tmrMoveBall = new System.Windows.Forms.Timer(this.components);
			this.SuspendLayout();
			this.tmrMoveBall.Enabled = true;
			this.tmrMoveBall.Interval = 10;
			this.tmrMoveBall.Tick += new System.EventHandler(this.tmrMoveBall_Tick);
			this.ClientSize = new System.Drawing.Size(600, 600);
			this.Name = "Form1";
			this.Text = "Bouncing Balls";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
			this.BackColor = Color.Black;
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.ResumeLayout(false);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Initialize some random stuff.
		private void Form1_Load(object sender, EventArgs e)
		{
			// Use double buffering to reduce flicker.
			this.SetStyle(
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.UserPaint |
				ControlStyles.DoubleBuffer,
				true);
			this.UpdateStyles();
		}

		// Update the ball's position, bouncing if necessary.
		protected abstract void tmrMoveBall_Tick(object sender, EventArgs e);
		
		// Draw the ball at its current location.
		protected abstract void Form1_Paint(object sender, PaintEventArgs e);
	}
}
