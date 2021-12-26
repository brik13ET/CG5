using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5
{
	class Model3D
	{
		public int[,] lines;
		public Vec4[] vertex;
		public int w = 20;
		public int h = 20;

		public void Gen(double Soxy, double Sz, int radius)
		{
			vertex = new Vec4[w * h + 1];
			int i = 0;
			for (int a_h = -90; a_h <= 90; a_h += 180 / h)
			{
				double
					s_h = Math.Sin(a_h * Math.PI / 180),
					c_h = Math.Cos(a_h * Math.PI / 180);
				if (a_h == -90 )
				{
					var v = new Vec4
					(
						0,
						0,
						-radius * Sz,
						1
					);
					vertex[i] = v;
					i++;
				}
				else if (a_h == 90)
				{
					var v = new Vec4
					(
						0,
						0,
						radius * Sz,
						1
					);
					vertex[i] = v;
					i++;
				}
				else
					for (int a_w = 0; a_w <= 360; a_w+= 360 / w)
					{
						double
							s_w = Math.Sin(a_w * Math.PI / 180),
							c_w = Math.Cos(a_w * Math.PI / 180);
						var v = new Vec4
						(
							radius * Soxy * c_h * c_w,
							radius * Soxy * c_h * s_w,
							-radius * Sz * (s_h >= 0 ? s_h : Math.Sin(0.5f * a_h * Math.PI / 180) + s_h),
							1
						);
						vertex[i] = v;
						i++;
					}
			}


			lines = new int[(w + 1) * (h + 1) * 2 - w * 2, 2];
			i = 0;
			for (int a = 0; a <= h; a++)
			{
				if (a == 0)
					for (int b = 0; b <= w; b++)
					{
						lines[i, 0] = 0;
						lines[i, 1] = b;
						i++;
					}
				else if (a == h)
					for (int b = 0; b <= w; b++)
					{
						lines[i, 0] = (h-2)*w + b % w;
						lines[i, 1] = w*(h - 2) + (w - 1) * 2;
						i++;
					}
				else
					for (int b = 0; b <= w; b++)
					{
						lines[i, 0] = a * w + b;
						lines[i, 1] = a * w + (b + 1) % w;
						i++;
						lines[i, 0] = a * w + b;
						lines[i, 1] = (a + 1) * w + (b + 1) % w;
						i++;
					}
			}
		}
	}
}
