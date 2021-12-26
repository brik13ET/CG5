using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG5_2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			vao = Gen(20, 20, out lines);
			double
				w = pictureBox1.Width,
				h = pictureBox1.Height;
			projection = new Mat4
			(
				1, -1, 0, w/2,
				0.5, 0.5, -1, h/2,
				0, 0, 0, 0,
				0, 0, 0, 1
			);
			screen = new Bitmap((int)w, (int)h);
			g = pictureBox1.CreateGraphics();
			Draw();
		}

		Vec4[] vao;
		Mat4 projection;
		Mat4 transform_scale = Mat4.identity;
		Mat4 transform_rotate= Mat4.identity;
		Mat4 transform_move = Mat4.identity;
		Mat4 transform
		{
			get { return transform_move * transform_scale * transform_rotate; }
		}
		Bitmap screen;
		int[,] lines;
		Graphics g;
		double radius;

		private void pictureBox1_Resize(object sender, EventArgs e)
		{
			double
				w = pictureBox1.Width,
				h = pictureBox1.Height;
			projection[0, 3] = 0.5f * w;
			projection[1, 3] = 0.5f * h;
			//screen = new Bitmap((int)w, (int)h);
			g = pictureBox1.CreateGraphics();
			Draw();
			this.Text = string.Format("w: {0}   h: {1}", w, h);
		}

		public Vec4[] Gen(int w, int h, out int[,] lines)
		{
			Vec4[] vert_buf = new Vec4[w * h + 1];
			int i = 0;
			for (int h_a = -90; h_a <= 90; h_a += 180 / h)
			{
				if (h_a == -90)
				{
					vert_buf[i] = new Vec4(0, 0, -radius);
					i++;
				}
				else if (h_a >= 90)
				{
					vert_buf[i] = new Vec4(0, 0, 2 * radius);
					i++;
				}
				else
				{
					double
						sh = Math.Sin(h_a * Math.PI / 180),
						ch = Math.Cos(h_a * Math.PI / 180);
					for (int w_a = 0; w_a <= 360; w_a += 360 / w)
					{
						double
								sw = Math.Sin(w_a * Math.PI / 180),
								cw = Math.Cos(w_a * Math.PI / 180);
						if (h_a <= 0)
							vert_buf[i] = new Vec4
							(
								radius * cw * ch,
								radius * sw * ch,
								radius * sh
							);
						else // if (h_a > 0)
							vert_buf[i] = new Vec4
							(
								radius * cw * (h_a / 90f),
								radius * sw * (h_a / 90f),
								2f * radius * ( 1f - h_a / 90f)
							);
						i++;
					}
				}
			}

			lines = new int[w * h * 2 + w, 2];
			int lines_i = 0;
			for (int hv = 0; hv < h; hv++)
			{
				for (int wv = 0; wv < w; wv++)
				{
					if (hv == 0)
					{
						lines[lines_i, 0] = 0;
						lines[lines_i, 1] = 1 + wv;
						lines_i++;
						// 2 layer to 1st vertex
					}
					else if (hv == 1) // hor layers count > vertical lines
					{
						lines[lines_i, 0] = wv % w;
						lines[lines_i, 1] = 1 + wv % w;
						lines_i++;
					}
					else
					{
						if (hv * w + ((wv + 1) % w) < vert_buf.Length)
						{
							lines[lines_i, 0] = hv * w + wv;
							lines[lines_i, 1] = hv * w + ((wv - 1) % w);
							lines_i++;
						}
						if ((hv + 1) * w + wv + 1 < vert_buf.Length)
						{
							lines[lines_i, 0] = hv * w + wv;
							lines[lines_i, 1] = (hv + 1) * w + wv + 1;
							lines_i++;
						}
					}
				}
			}
			return vert_buf;
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
				if (x < b.Width && x >= 0 && y < b.Height && y >= 0)
					b.SetPixel(x, y, Color.White);
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

		private void Draw()
		{
			
			Vec4[] curr_v = new Vec4[vao.Length];
			int
				w = pictureBox1.Width,
				h = pictureBox1.Height;
			screen = new Bitmap(w, h);
			for (int i = 0; i < vao.Length; i++)
			{
				curr_v[i] = projection * transform * vao[i];
				/*if
				(
					curr_v[i].x >= 0 && curr_v[i].x < w &&
					curr_v[i].y >= 0 && curr_v[i].y < h
				)
				screen.SetPixel((int)curr_v[i].x, (int)curr_v[i].y, Color.Red);*/
			}
			for (int i = 0; i < lines.GetLength(0) ; i++)
			{
				line
				(
					(int)curr_v[lines[i, 0]].x,
					(int)curr_v[lines[i, 0]].y,
					(int)curr_v[lines[i, 1]].x,
					(int)curr_v[lines[i, 1]].y,
					screen
				);
			}


			pictureBox1.Image = screen;
		}
		
		public void rotate (double ax, double ay, double az)
		{
			double
				cx = Math.Cos(ax),
				sx = Math.Sin(ax),
				cy = Math.Cos(ay),
				sy = Math.Sin(ay),
				cz = Math.Cos(az),
				sz = Math.Sin(az);
			transform_rotate =
			new Mat4
			(
				cz, -sz, 0, 0,
				sz, cz, 0, 0,
				0, 0, 1, 0,
				0, 0, 0, 1
			) *
			new Mat4
			(
				1, 0, 0, 0,
				0, cx, -sx, 0,
				0, sx, cx, 0,
				0, 0, 0, 1
			) *
			new Mat4
			(
				cy, 0, -sy, 0,
				0,	1, 0,	0,
				sy, 0, cy, 0,
				0, 0, 0, 1
			);

		}

		private void trackBar2_Scroll(object sender, EventArgs e)
		{
			double s = (sender as TrackBar).Value;
			int
				min = (sender as TrackBar).Minimum,
				max = (sender as TrackBar).Maximum;
			//s = 1 + s * 0.1f;
			s = s * 2f / (max - min);
			transform_scale =
				new Mat4
				(
					s, 0, 0, 0,
					0, s, 0, 0,
					0, 0, s, 0,
					0, 0, 0, 1
				);
			Draw();
		}
		
		Mat4
			rot_z = Mat4.identity,
			rot_y = Mat4.identity;


		bool rotating = false;
		Point pos0;

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			rotating = e.Button == MouseButtons.Left;
			if (rotating)
				pos0 = e.Location;
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			if (rotating)	
			{
				rotate(
					0,
					(e.Y - pos0.Y) * Math.PI / pictureBox1.Height,
					(e.X - pos0.X) * Math.PI / pictureBox1.Width
					);
				Draw();
			}
		}

		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			rotating = e.Button != MouseButtons.Left;
			Draw();
		}

		int _x,
			_y;

		private void trackBar3_Scroll(object sender, EventArgs e)
		{
			rotate(
				0,
				Math.PI * trackBar4.Value / trackBar3.Maximum,
				Math.PI * trackBar3.Value / trackBar3.Maximum
			);
			Draw();
		}
				
		private void trackBar5_Scroll(object sender, EventArgs e)
		{
			transform_move = new Mat4
			(
				1, 0, 0, (sender as TrackBar).Value,
				0, 1, 0, (sender as TrackBar).Value,
				0, 0, 1, 0,
				0, 0, 0, 1
			);
			Draw();
		}

		private void trackBar4_Scroll(object sender, EventArgs e)
		{
			rotate(
				0,
				Math.PI * trackBar4.Value / trackBar3.Maximum,
				Math.PI * trackBar3.Value / trackBar3.Maximum
			);
			Draw();
		}

		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			radius = (sender as TrackBar).Value;
			vao = Gen(20, 20, out lines);
			Draw();
		}
	}
}
