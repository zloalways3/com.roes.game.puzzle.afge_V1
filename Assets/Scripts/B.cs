using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class B : MonoBehaviour
{
	[SerializeField] private TTA[] tt;
	[SerializeField] private R[] r;
	[SerializeField] private float td;
	[SerializeField] private Transform so;
	[SerializeField] private bool ensm;
	[SerializeField] private GC gc;
	private readonly List<TI> s = new List<TI>();
	private bool iss;
	private bool ism;
	private bool issh;
	public event Action<TTA, int> om;

	private TD[,] M
	{
		get
		{
			var w1 = r.Max(row => row.it.Length);
			var h1 = r.Length;
			var d1 = new TD[w1, h1];
			for (var y1 = 0; y1 < h1; y1++)
			{
				for (var x1 = 0; x1 < w1; x1++)
				{
					d1[x1, y1] = GT(x1, y1).Data;
				}
			}
			return d1;
		}
	}

	public void UB()
	{
		S();
		StartCoroutine(ENSM());
	}

	private void Start()
	{
		for (var y1 = 0; y1 < r.Length; y1++)
		{
			for (var x1 = 0; x1 < r.Max(row => row.it.Length); x1++)
			{
				var t0 = GT(x1, y1);
				t0.x1 = x1;
				t0.y1 = y1;
				t0.Type = tt[Random.Range(0, tt.Length)];
				t0.but.onClick.AddListener(() => ST(t0));
			}
		}

		if (ensm) StartCoroutine(ENSM());
		om += (type, count) => gc.UP(count, type.a);
	}

	public void S()
	{
		issh = true;
		foreach (var row in r)
		{
			foreach (var tile in row.it)
			{
				tile.Type = tt[Random.Range(0, tt.Length)];
			}
		}
		issh = false;
	}

	private async Task<bool> TMA()
	{
		var dm = false; ism = true; var m = TDMU.F(M);
		while (m != null)
		{
			dm = true;
			var t1 = GT(m.c);
			var ds = DOTween.Sequence();
			foreach (var tile in t1)
			{
				ds.Join(tile.ic.transform.DOScale(Vector3.zero, td).SetEase(Ease.InBack));
			}
			gc.CS1();
			await ds.Play()
								 .AsyncWaitForCompletion();
			var isq = DOTween.Sequence();
			foreach (var tile in t1)
			{
				tile.Type = tt[Random.Range(0, tt.Length)];
				isq.Join(tile.ic.transform.DOScale(new Vector2(0.8f, 0.8f), td).SetEase(Ease.OutBack));
			}
			await isq.Play()
								 .AsyncWaitForCompletion();
			om?.Invoke(Array.Find(tt, tileType => tileType.a == m.a), m.c.Length);
			m = TDMU.F(M);
		}
		ism = false; return dm;
	}

	private async void ST(TI tile)
	{
		if (iss || ism || issh)
		{
			return;
		}
		if (!s.Contains(tile))
		{
			if (s.Count > 0)
			{
				if (Math.Abs(tile.x1 - s[0].x1) == 1 && Math.Abs(tile.y1 - s[0].y1) == 0
					|| Math.Abs(tile.y1 - s[0].y1) == 1 && Math.Abs(tile.x1 - s[0].x1) == 0)
				{
					s.Add(tile);
				}
			}
			else
			{
				s.Add(tile);
			}
		}

		if (s.Count < 2)
		{
			return;
		}
		await SA(s[0], s[1]);
		if (!await TMA())
		{
			await SA(s[0], s[1]);
		}
		var matrix = M;
		while (TDMU.MBF(matrix) == null || TDMU.F(matrix) != null)
		{
			S();
			matrix = M;
		}
		s.Clear();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			var bm = TDMU.MBF(M);
			if (bm != null)
			{
				ST(GT(bm.a, bm.b));
				ST(GT(bm.c, bm.d1));
			}
		}
	}

	private IEnumerator ENSM()
	{
		var w1 = new WaitForEndOfFrame();
		while (TDMU.F(M) != null)
		{
			S();
			yield return w1;
		}
	}

	private TI GT(int x, int y) => r[y].it[x];

	private TI[] GT(IList<TD> tileData)
	{
		var length = tileData.Count;
		var it = new TI[length];
		for (var i4 = 0; i4 < length; i4++)
		{
			it[i4] = GT(tileData[i4].X1, tileData[i4].Y1);
		}
		return it;
	}

	private async Task SA(TI t1, TI t2)
	{
		iss = true;
		var i1 = t1.ic;
		var i2 = t2.ic;
		var i1t = i1.transform;
		var i2t = i2.transform;
		i1t.SetParent(so);
		i2t.SetParent(so);
		i1t.SetAsLastSibling();
		i2t.SetAsLastSibling();
		var seq = DOTween.Sequence();
		seq.Join(i1t.DOMove(i2t.position, td).SetEase(Ease.OutBack)).Join(i2t.DOMove(i1t.position, td).SetEase(Ease.OutBack));
		await seq.Play().AsyncWaitForCompletion();
		i1t.SetParent(t2.transform);
		i2t.SetParent(t1.transform); t1.ic = i2; t2.ic = i1;
		var tileOneItem = t1.Type; t1.Type = t2.Type; t2.Type = tileOneItem;
		iss = false;
	}
}