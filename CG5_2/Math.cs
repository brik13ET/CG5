using System;
using System.Collections.Generic;

public class Vec4
{
	double[] v;

	public double this[int i]
	{
		get { return v[i]; }
		set { v[i] = value; }
	}

	public double x
	{
		get { return v[0]; }
		set { v[0] = value; }
	}
	public double y
	{
		get { return v[1]; }
		set { v[1] = value; }
	}
	public double z
	{
		get { return v[2]; }
		set { v[2] = value; }
	}
	public double h
	{
		get { return v[3]; }
		set { v[3] = value; }
	}

	public Vec4(double x = 0, double y = 0, double z = 0, double h = 1)
	{
		this.v = new double[] { x, y, z, h };
	}
	public Vec4(Vec4 v)
	{
		this.v = new double[4];
		for (int i = 0; i < 4; i++)
			this.v[i] = v[i];
	}
	
	public static Vec4 operator *(double q, Vec4 v)
	{
		Vec4 ret = new Vec4(v);
		for (int i = 0; i < 4; i++)
			ret[i] = ret[i] * q;
		return ret;
	}

	public double Abs(Vec4 v)
	{
		return (1f / h) * Math.Sqrt(x * x + y * y + z * z);
	}
}
public class Mat4
{
	private double[,] m;

	/// <summary>
	/// addr: _Y_X
	/// </summary>
	public double this[int r, int c]
	{
		get { return m[r, c]; }
		set { m[r, c] = value; }
	}

	public static readonly Mat4 identity = new Mat4
	(
		1, 0, 0, 0,
		0, 1, 0, 0,
		0, 0, 1, 0,
		0, 0, 0, 1
	);

	public Mat4 ( Mat4 m )
	{
		this.m = new double[4, 4];
		for (int i = 0; i < 4; i++)
			for (int j = 0; j < 4; j++)
				this.m[i, j] = m[i, j];
	}
	/// <summary>
	/// addr: _Y_X
	/// </summary>
	public Mat4
	(
		double _0_0 = 1, double _0_1 = 0, double _0_2 = 0, double _0_3 = 0,
		double _1_0 = 0, double _1_1 = 1, double _1_2 = 0, double _1_3 = 0,
		double _2_0 = 0, double _2_1 = 0, double _2_2 = 1, double _2_3 = 0,
		double _3_0 = 0, double _3_1 = 0, double _3_2 = 0, double _3_3 = 1
	)
	{
		m = new double[,]
		{
			{ _0_0, _0_1, _0_2, _0_3 },
			{ _1_0, _1_1, _1_2, _1_3 },
			{ _2_0, _2_1, _2_2, _2_3 },
			{ _3_0, _3_1, _3_2, _3_3 }
		};
	}

	public static Vec4 operator* (Mat4 m, Vec4 v)
	{
		Vec4 ret = new Vec4();
		for (int i = 0; i < 4; i++)
			for (int j = 0; j < 4; j++)
				ret[i] += m[i, j] * v[j];
		return ret;
	}
	public static Mat4 operator* (Mat4 m1, Mat4 m2)
	{
		Mat4 ret = new Mat4(0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0);
		for (int i = 0; i < 4; i++)
			for (int j = 0; j < 4; j++)
				for (int k = 0; k < 4; k++)
					ret[i,j] += m1[i, k] * m2[k, j];
		return ret;

}
	public static Mat4 operator *(double q, Mat4 m)
	{
		Mat4 ret = new Mat4(m);
		for (int i = 0; i < 4; i++)
			for (int j = 0; j < 4; j++)
				ret[i, j] = ret[i, j] * q;
		return ret;
	}

	public static Mat4 Clone (Mat4 m1)
	{
		return new Mat4(m1);
	}

	public Mat4 Transp()
	{
		Mat4 ret = new Mat4(this);
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				double c = ret.m[i, j];
				ret.m[i, j] = ret.m[j, i];
				ret.m[j, i] = c;
			}
		}
		return ret;
	}
	
}
class Surface
{
	public double X_q = 0;
	public double Y_q = 0;
	public double Z_q = 0;
	public double D_q = 0;
}