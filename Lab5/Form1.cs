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
			int[,] lines;
			var v = Gen(10, 10, trackBar6.Value, out lines);
			Bitmap b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			Draw(v, lines, b);
			pictureBox1.Image = b;
		}
		
		public Vec3[] Gen(double Soxy, double Sz, int radius, out int[,] lines)
		{
			/*
			// Cube
			var ret = new Vec3[]
			{
				new Vec3 (-Soxy, -Soxy, -Sz),
				new Vec3 (Soxy, -Soxy, -Sz),
				new Vec3 (Soxy, Soxy, -Sz),
				new Vec3 (-Soxy, Soxy, -Sz),
				new Vec3 (-Soxy, -Soxy, Sz),
				new Vec3 (Soxy, -Soxy, Sz),
				new Vec3 (Soxy, Soxy, Sz),
				new Vec3 (-Soxy, Soxy, Sz),
			};
			
			lines = new int[,]
			{
				{0,1 },
				{1,2 },
				{2,3 },
				{3,0 },

				{0,4 },
				{1,5 },
				{2,6 },
				{3,7 },

				{4,5 },
				{5,6 },
				{6,7 },
				{7,4 }
			};
			*/
			const int h = 45, w = 90; // h from -90 to 90, w from -180 to 180
			Vec3[] ret = new Vec3[w*h];
			int i = 0;
			for (int a_h = -h / 2; a_h < h - h / 2; a_h++)
			{
				double
					s_h = Math.Sin(a_h * (180 / h) * Math.PI / 180),
					c_h = Math.Cos(a_h * (180 / h) * Math.PI / 180);
					for (int a_w = 0; a_w < w; a_w++)
					{
						double
							s_w = Math.Sin(a_w * (360f / w) * Math.PI / 180),
							c_w = Math.Cos(a_w * (360f / w) * Math.PI / 180);
						var v = new Vec3
						(
							radius * Soxy * c_h * c_w,
							radius * Soxy * c_h * s_w,
							-radius * Sz *  (s_h >= 0 ? s_h : Math.Sin(0.5f* a_h * (180 / h) * Math.PI / 180) + s_h)
						);
						ret[i] = v;
						i++;
					}
			}

			
			lines = new int[w * h *2, 2];
			i = 0;
			for (int a = 0; a < h; a++)
				for (int b = 0; b < w; b++)
				{
					if (i+1 < lines.GetLength(0))
					{
						lines[i, 0] = a * w + b;
						lines[i, 1] = a * w + (b + 1) % w;
						i++;
					}
					if (i + 1 < lines.GetLength(0) && (a + 1) % h != 0)
					{
						lines[i, 0] = a * w + b;
						lines[i, 1] = ((a+1) % h) * w + b ;
						i++;
					}
				}
			return ret;
		}

		public void Draw(Vec3[] v, int[,] lines, Bitmap g)
		{

			Vec3[] __v = new Vec3[v.Length];


			for (int i = 0; i < v.Length; i++)
			{
				Vec4 _v = cur * (new Vec4(v[i]));
				__v[i] = new Vec3(g.Width / 2 + (int)_v.x, g.Height / 2 - (int)_v.z, 0);
			}
			for (int i = 0; i < lines.GetLength(0); i++)
			{
				if ((int)__v[lines[i, 0]].x != 0 &&	(int)__v[lines[i, 0]].y != 0)
				line
				(
					(int)__v[lines[i, 0]].x,
					(int)__v[lines[i, 0]].y,
					(int)__v[lines[i, 1]].x,
					(int)__v[lines[i, 1]].y,
					g
				);
			}
			/*
			for (int i = 0; i < v.Length; i++)
				if(
					(int)__v[i].x < g.Width &&
					(int)__v[i].x >= 0 &&
					(int)__v[i].y < g.Height &&
					(int)__v[i].y >= 0

					)
					g.SetPixel((int)__v[i].x, (int)__v[i].y, Color.Red);
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
			int[,] lines;
			var v = Gen((trackBar1.Value / 10) * (trackBar2.Value / 10), (trackBar1.Value * 1f / 10) * (trackBar3.Value*1f / 10), trackBar6.Value, out lines);
			var b = new Bitmap(pictureBox1.Width, pictureBox1.Height);
			Draw(v, lines, b);
			pictureBox1.Image = b;
			
			___v = new Vec4[v.Length];
			for (int i = 0; i < v.Length; i++)
				___v[i] = new Vec4(v[i]);
			
		}

		Vec4[] ___v;
		bool move;
		Mat4 _0m;
		Mat4 cur = Mat4.identity;

		Point _0;

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			_0 = e.Location;
			_0m = new Mat4(cur);
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

				uv_rotate(-Math.PI * dy / this.Height, Math.PI * dx / this.Width, 0);
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
			double
			co_v = Math.Cos(dx),
			si_v = Math.Sin(dx),
			si = Math.Sin(dy),
			co = Math.Cos(dy),
			co_g = Math.Sin(dz),
			si_g = Math.Cos(dz);
			var rot_h = new Mat4
			(
				 co,	si,	0,	0,
				-si,	co,	0,	0,
				 0, 	0,	1,	0,
				 0,		0,	0,	1
			);
			var rot_v = new Mat4
			(
				co_v,	0,	si_v,	0,
				0,  	1,	0,  	0,
				-si_v,	0,	co_v,	0,
				0,  	0,	0,  	1
			);
			var rot_g = new Mat4
			(
				1,	0,  	0,  	0,
				0,	co_g,	si_g,	0,
				0,	-si_g,	co_g,	0,
				0,	0,  	0,  	1
			);
			cur = rot_v * rot_h * rot_g ;

		}

		private void trackBar2_Scroll(object sender, EventArgs e)
		{
			update();

		}
		
		private void trackBar4_Scroll_1(object sender, EventArgs e)
		{
			uv_rotate
			(
				trackBar4.Value * Math.PI / (180),
				trackBar5.Value * Math.PI / (180),
				trackBar7.Value * Math.PI / (180)
			);
			update();

		}

		private void trackBar5_Scroll(object sender, EventArgs e)
		{

			uv_rotate
			(
				trackBar4.Value * Math.PI / (180),
				trackBar5.Value * Math.PI / (180),
				trackBar7.Value * Math.PI / (180)
			);
			update();

		}

		private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
		{

		}

		private void trackBar7_Scroll_1(object sender, EventArgs e)
		{
			uv_rotate
			(
				trackBar4.Value * Math.PI / (180),
				trackBar5.Value * Math.PI / (180),
				trackBar7.Value * Math.PI / (180)
			);
			update();

		}
	}
}
