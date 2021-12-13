using System;

namespace Lab5
{
	public class Vec4
	{
		private double[] m;

		public double this[int i]
		{
			get
			{
				return m[i];
			}
			set
			{
				m[i] = value;
			}
		}

		public double x
		{
			get { return m[0]; }
			set { m[0] = value; }
		}
		public double y
		{
			get { return m[1]; }
			set { m[1] = value; }
		}
		public double z
		{
			get { return m[2]; }
			set { m[2] = value; }
		}
		public double h
		{
			get { return m[3]; }
			set { m[3] = value; }
		}

		public Vec4(Vec3 v)
		{
			m = new double[4] { v.x, v.y, v.z, 1 };
		}

		public Vec4(double x = 0, double y = 0, double z = 0, double h = 0)
		{
			m = new double[4] { x, y, z, h };
		}

		public static Vec4 operator *(Mat4 m, Vec4 v)
		{
			Vec4 ret = new Vec4();
			for (int j = 0; j < 4; j++)
				for (int i = 0; i < 4; i++)
					ret[j] += m[i, j] * v[i];
			return ret;
		}

		public override string ToString()
		{
			return string.Format("Vec4{{ x: {0}, y: {1}, z: {2}, h: {3} }}", m[0], m[1], m[2], m[3]);
		}
	}

	public class Mat4
	{
		public static Mat4 identity = new Mat4(1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1);

		private double[,] m;

		public double this[int i, int j]
		{
			get
			{
				return m[i, j];
			}
			set
			{
				m[i, j] = value;
			}
		}

		public Mat4()
		{
			m = new double[4, 4];
		}

		public Mat4 (Mat3 m)
		{
			this.m = new double[4, 4]
			{
				{ m[0,0], m[1,0], m[2,0], 0},
				{ m[0,1], m[1,1], m[2,1], 0 },
				{ m[0,2], m[1,2], m[2,2], 0 },
				{ 0, 0, 0, 1 }
			};
		}

		public Mat4(Mat4 m)
		{
			this.m = new double[4, 4];
			for (int i = 0; i < 4; i++)
				for (int j = 0; j < 4; j++)
					this.m[i, j] = m.m[i, j];
		}

		public Mat4
		(
			double _0_0, double _1_0, double _2_0, double _3_0,
			double _0_1, double _1_1, double _2_1, double _3_1,
			double _0_2, double _1_2, double _2_2, double _3_2,
			double _0_3, double _1_3, double _2_3, double _3_3

		)
		{
			m = new double[4, 4]
			{
				{ _0_0, _1_0, _2_0, _3_0},
				{ _0_1, _1_1, _2_1, _3_1 },
				{ _0_2, _1_2, _2_2, _3_2 },
				{ _0_3, _1_3, _2_3, _3_3 }
			};
		}

		public static Mat4 operator *(Mat4 m1, Mat4 m2)
		{
			Mat4 ret = new Mat4();
			for (int i = 0; i < 4; i++)
				for (int j = 0; j < 4; j++)
					for (int k = 0; k < 4; k++)
						ret[i, j] += m1[i, k] * m2[k, j];
			return ret;
		}
		public override string ToString()
		{
			return string.Format
			(
			"Mat4{{\n{0:00.00}\t{1:00.00}\t{2:00.00}\t{3:00.00}\n{4:00.00}\t{5:00.00}\t{6:00.00}\t{7:00.00}\n{8:00.00}\t{9:00.00}\t{10:00.00}\t{11:00.00}\n{12:00.00}\t{13:00.00}\t{14:00.00}\t{15:00.00}\n}}",
			m[0, 0], m[1, 0], m[2, 0], m[3, 0], m[0, 1], m[1, 1], m[2, 1], m[3, 1], m[0, 2], m[1, 2], m[2, 2], m[3, 2], m[0, 3], m[1, 3], m[2, 3], m[3, 3]
			);
		}

	}

	public class Vec3
	{
		private double[] m;

		public double this[int i]
		{
			get
			{
				return m[i];
			}
			set
			{
				m[i] = value;
			}
		}

		public double x
		{
			get { return m[0]; }
			set { m[0] = value; }
		}
		public double y
		{
			get { return m[1]; }
			set { m[1] = value; }
		}
		public double z
		{
			get { return m[2]; }
			set { m[2] = value; }
		}

		public Vec3(double x = 0, double y = 0, double z = 0)
		{
			m = new double[3] { x, y, z };
		}

		public static Vec3 operator *(Mat3 m, Vec3 v)
		{
			Vec3 ret = new Vec3();
			for (int j = 0; j < 3; j++)
				for (int i = 0; i < 3; i++)
					ret[j] += m[i, j] * v[i];
			return ret;
		}

		public override string ToString()
		{
			return string.Format("Vec3{ x: {0}, y: {1}, z: {2} }", m[0], m[1], m[2]);
		}
	}

	public class Mat3
	{
		private double[,] m;

		public double this[int i, int j]
		{
			get
			{
				return m[i, j];
			}
			set
			{
				m[i, j] = value;
			}
		}

		public Mat3()
		{
			m = new double[3, 3];
		}

		public Mat3
		(
			double _0_0, double _1_0, double _2_0,
			double _0_1, double _1_1, double _2_1,
			double _0_2, double _1_2, double _2_2
		)
		{
			m = new double[3, 3] { { _0_0, _1_0, _2_0 }, { _0_1, _1_1, _2_1 }, { _0_2, _1_2, _2_2 } };
		}

		public static Mat3 operator *(Mat3 m1, Mat3 m2)
		{
			Mat3 ret = new Mat3();
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 3; j++)
					for (int k = 0; k < 3; k++)
						ret[i, j] += m1[i, k] * m2[k, j];
			return ret;
		}

		public override string ToString()
		{
			return string.Format
			(
			"Mat3{ {0:00.00} {1:00.00} {2:00.00}\n{3:00.00} {4:00.00} {5:00.00}\n{6:00.00} {7:00.00} {8:00.00}}",
			m[0, 0], m[1, 0], m[2, 0], m[0, 1], m[1, 1], m[2, 1], m[0, 2], m[1, 2], m[2, 2]
			);
		}
	}
}