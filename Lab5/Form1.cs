using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			model = new Model3D();

		}

		Model3D model;
		
		public void Draw(Bitmap g)
		{
			
			Vec4[] __v = new Vec4[model.vertex.Length];


			for (int i = 0; i < model.vertex.Length; i++)
			{
				Vec4 _v = cur * model.vertex[i];
				__v[i] =
				cur *
				(
					new Mat4
					(
						1, 0, 0, pictureBox1.Width / 2f,
						0, 1, 1, pictureBox1.Height / 2f,
						0, 0, 0, 0,
						0, 0, 0, 1
					)
				) * _v;
				if (
					__v[i].x >= 0 && __v[i].x < g.Width &&
					__v[i].y >= 0 && __v[i].y < g.Height
					)
					g.SetPixel((int)__v[i].x, (int)__v[i].y, Color.White);
			}
			/*
			for (int i = 0; i < model.lines.GetLength(0); i++)
			{
					line
					(
						(int)__v[model.lines[i, 0]].x,
						(int)__v[model.lines[i, 0]].y,
						(int)__v[model.lines[i, 1]].x,
						(int)__v[model.lines[i, 1]].y,
						g
					);
			}
			*/
		}

		public void line(int x, int y, int x2, int y2, Bitmap b)
		{
			int w = x2 - x;
			int h = y2 - y;
			int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
			if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
			if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
			if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
			int longest = Math.Abs(w);
			int shortest = Math.Abs(h);
			if (!(longest > shortest))
			{
				longest = Math.Abs(h);
				shortest = Math.Abs(w);
				if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
				dx2 = 0;
			}
			int numerator = longest >> 1;
			for (int i = 0; i <= longest; i++)
			{
				if (x < b.Width && x >= 0 && y <b.Height && y >= 0)
					b.SetPixel(x, y,Color.White);
				numerator += shortest;
				if (!(numerator < longest))
				{
					numerator -= longest;
					x += dx1;
					y += dy1;
				}
				else
				{
					x += dx2;
					y += dy2;
				}
			}
		}

		void update()
		{
			model.Gen
			(
				trackBar1.Value * trackBar2.Value * 10f / (trackBar1.Maximum * trackBar2.Maximum),
				trackBar1.Value * trackBar3.Value * 10f / (trackBar1.Maximum * trackBar3.Maximum),
				trackBar6.Value
			);
			var b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			Draw(b);
			pictureBox1.Image = b;
		}

		Vec4[] ___v;
		bool move;
		Mat4 cur = Mat4.identity;

		Point _0;

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			_0 = e.Location;
			move = true;
		}

		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			move = false;
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			if (move)
			{
				int
				dx = e.Location.X - _0.X,
				dy = e.Location.Y - _0.Y;

				update();
			}
		}


		private void button1_Click(object sender, EventArgs e)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < ___v.Length; i++)
			{
				sb.AppendLine(___v[i].ToString());
			}
			MessageBox.Show(sb.ToString());
		}
		
		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			label7.Text = (sender as TrackBar).Value.ToString();
			update();
		}

		private void trackBar3_Scroll(object sender, EventArgs e)
		{
			update();
		}
		
		private void uv_rotate(double dz, double dx, double dy)
		{


		}

		private void trackBar2_Scroll(object sender, EventArgs e)
		{
			update();

		}
		
		private void trackBar4_Scroll_1(object sender, EventArgs e)
		{

			update();

		}

		private void trackBar5_Scroll(object sender, EventArgs e)
		{


			update();

		}

		private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void trackBar7_Scroll_1(object sender, EventArgs e)
		{

			update();

		}
	}

}
