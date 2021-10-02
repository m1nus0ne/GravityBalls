using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GravityBalls
{
	public class BallsForm : Form
	{
		private Timer timer;
		private WorldModel world;

		private WorldModel CreateWorldModel()
		{
			var w = new WorldModel
			{
				WorldHeight = ClientSize.Height,
				WorldWidth = ClientSize.Width,
				BallRadius = 40,
				VelocityX = 0,
				VelocityY = 0,
				Resistance = 0.9,
				Gravity = 50000,
				Forсe = 10000000



			};
			w.BallX = w.WorldHeight / 2;
			w.BallY = w.BallRadius * 2;
			
			return w;
		}

		

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			world.WorldHeight = ClientSize.Height;
			world.WorldWidth = ClientSize.Width;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			DoubleBuffered = true;
			BackColor = Color.Black;
			world = CreateWorldModel();
			timer = new Timer { Interval = 5 };
			timer.Tick += TimerOnTick;
			timer.Start();
			world.WorldHeight = ClientSize.Height;
			world.WorldWidth = ClientSize.Width;
		}

		private void TimerOnTick(object sender, EventArgs eventArgs)
		{
			world.SimulateTimeframe(timer.Interval / 1000d);
			Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			var g = e.Graphics;
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.FillEllipse(Brushes.GreenYellow,
				(float)(world.BallX - world.BallRadius),
				(float)(world.BallY - world.BallRadius),
				2 * (float)world.BallRadius,
				2 * (float)world.BallRadius);
		}

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			Text = string.Format("Cursor ({0}, {1})", e.X, e.Y);
			world.MouseCordX = e.X;
			world.MouseCordY = e.Y;
		}
	}
}