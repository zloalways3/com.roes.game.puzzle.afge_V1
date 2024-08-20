using UnityEngine;
using UnityEngine.UI;

public sealed class TI : MonoBehaviour
{
	public int x1;
	public int y1;
	public Image ic;
	public Button but;
	private TTA _type;

	public TTA Type
	{
		get => _type;

		set
		{
			if (_type == value) return;

			_type = value;

			ic.sprite = _type.c;
		}
	}

	public TD Data => new TD(x1, y1, _type.a);
}