using System.Collections.Generic;

public static class TDMU
{
	public static void S(int a, int b, int c, int d, TD[,] e)
	{
		var f1 = e[a, b]; e[a, b] = e[c, d]; e[c, d] = f1;
	}

	public static (TD[], TD[]) G3(int a, int b, TD[,] c)
	{
		var d1 = c[a, b];
		var e1 = c.GetLength(0);
		var f1 = c.GetLength(1);
		var g = new List<TD>();
		var h1 = new List<TD>();

		for (var i1 = a - 1; i1 >= 0; i1--)
		{
			var j1 = c[i1, b];
			if (j1.TypeId != d1.TypeId)
			{
				break;
			}
			g.Add(j1);
		}

		for (var i2 = a + 1; i2 < e1; i2++)
		{
			var j1 = c[i2, b];
			if (j1.TypeId != d1.TypeId)
			{
				break;
			}
			g.Add(j1);
		}

		for (var k = b - 1; k >= 0; k--)
		{
			var j3 = c[a, k];
			if (j3.TypeId != d1.TypeId)
			{
				break;
			}
			h1.Add(j3);
		}

		for (var k = b + 1; k < f1; k++)
		{
			var j5 = c[a, k];
			if (j5.TypeId != d1.TypeId)
			{
				break;
			}
			h1.Add(j5);
		}

		return (g.ToArray(), h1.ToArray());
	}

	public static M F(TD[,] a)
	{
		var b = default(M);

		for (var c = 0; c < a.GetLength(1); c++)
		{
			for (var d0 = 0; d0 < a.GetLength(0); d0++)
			{
				var e0 = a[d0, c];
				var (f, g) = G3(d0, c, a);
				var h0 = new M(e0, f, g);
				if (h0.b < 0) continue;
				if (b == null)
				{
					b = h0;
				}
				else if (h0.b > b.b) b = h0;
			}
		}
		return b;
	}

	public static List<M> FAM(TD[,] a)
	{
		var b = new List<M>();

		for (var c = 0; c < a.GetLength(1); c++)
		{
			for (var d0 = 0; d0 < a.GetLength(0); d0++)
			{
				var e0 = a[d0, c];
				var (f, g) = G3(d0, c, a);
				var h0 = new M(e0, f, g);
				if (h0.b > -1) b.Add(h0);
			}
		}

		return b;
	}

	private static (int, int) G2(byte a) => a switch
	{
		0 => (-1, 0),
		1 => (0, -1),
		2 => (1, 0),
		3 => (0, 1),
		_ => (0, 0),
	};


	public static MO FM(TD[,] a)
	{
		var b = (TD[,])a.Clone();

		var c = b.GetLength(0);
		var d0 = b.GetLength(1);

		for (var e0 = 0; e0 < d0; e0++)
		{
			for (var f1 = 0; f1 < c; f1++)
			{
				for (byte g = 0; g <= 3; g++)
				{
					var (h, i) = G2(g);
					var j0 = f1 + h;
					var k = e0 + i;
					if (j0 < 0 || j0 > c - 1 || k < 0 || k > d0 - 1) continue;
					S(f1, e0, j0, k, b);
					if (F(b) != null) return new MO(f1, e0, j0, k);
					S(j0, k, f1, e0, b);
				}
			}
		}
		return null;
	}


	public static MO MBF(TD[,] a)
	{
		var b = (TD[,])a.Clone();
		var c = b.GetLength(0);
		var d1 = b.GetLength(1);
		var e1 = int.MinValue;
		var f1 = default(MO);

		for (var g = 0; g < d1; g++)
		{
			for (var h1 = 0; h1 < c; h1++)
			{
				for (byte i1 = 0; i1 <= 3; i1++)
				{
					var (j, k) = G2(i1);
					var l = h1 + j;
					var m = g + k;
					if (l < 0 || l > c - 1 || m < 0 || m > d1 - 1) continue;
					S(h1, g, l, m, b);
					var n = F(b);
					if (n != null && n.b > e1)
					{
						f1 = new MO(h1, g, l, m);
						e1 = n.b;
					}
					S(h1, g, l, m, b);
				}
			}
		}
		return f1;
	}
}