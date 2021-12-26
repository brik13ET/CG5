using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
	public class model_3D
	{
		public Vec3[] vertex_list;
		public int[,] lines;
		public Mat4 cur = Mat4.identity;
		public byte accuracy = 8;

		public model_3D(byte accuracy = 8)
		{
			this.accuracy = accuracy;
		}

		public void Gen(double Soxy, double Sz, int radius)
		{
			int h = 180 / accuracy, w = 360 / accuracy; // h from -90 to 90, w from -180 to 180
			vertex_list = new Vec3[w * h - (w - 1) ];
			int i = 0;
			for (int a_h = -h / 2; a_h <= h - h / 2; a_h++)
			{
				double
					s_h = Math.Sin(a_h * (180 / h) * Math.PI / 180),
					c_h = Math.Cos(a_h * (180 / h) * Math.PI / 180);
				if (a_h == -h / 2)
				{
					vertex_list[i] = new Vec3
					(
						0,
						0,
						-radius * Sz
					);
					i++;
				}
				else if	(a_h == h - h / 2)
				{
					vertex_list[i] = new Vec3
					(
						0,
						0,
						radius * Sz
					);
					i++;
				}
				else
				for (int a_w = 0; a_w < w; a_w++)
				{
					double
						s_w = Math.Sin(a_w * (360f / w) * Math.PI / 180),
						c_w = Math.Cos(a_w * (360f / w) * Math.PI / 180);
					var v = new Vec3
					(
						radius * Soxy * c_h * c_w,
						radius * Soxy * c_h * s_w,
						-radius * Sz * (s_h >= 0 ? s_h : Math.Sin(0.5f * a_h * (180 / h) * Math.PI / 180) + s_h)

					);
					vertex_list[i] = v;
					i++;
				}
			}


			lines = new int[w * h * 2 - (w - 1) * 2 - h * 2, 2];
			i = 0;
			for (int a = 0; a <= h; a++)
				if (a == 0)
				{
					for (int b = 0; b < w; b++)
					{
						lines[i, 0] = 0;
						lines[i, 1] = a * w + (b + 1) % w;
					}
					i++;
				}
				else if ( a == h-1)
				{
					for (int b = 0; b < w; b++)
					{
						lines[i, 0] = a * w + b;
						lines[i, 1] = h * w ;
					}
					i++;
				} else
				for (int b = 0; b < w; b++)
				{
					if (i + 1 < lines.GetLength(0))
					{
						lines[i, 0] = a * w + b;
						lines[i, 1] = a * w + (b + 1) % w;
						i++;
					}
					if (i + 1 < lines.GetLength(0) && (a + 1) % h != 0)
					{
						lines[i, 0] = a * w + b;
						lines[i, 1] = ((a + 1) % h) * w + b;
						i++;
					}
				}
		}

	}
}
