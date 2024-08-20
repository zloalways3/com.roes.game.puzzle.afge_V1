using TMPro;
using UnityEngine;

public class T : MonoBehaviour
{
    [SerializeField] private float a;
    [SerializeField] private GC c;
    [SerializeField] private TextMeshProUGUI f1;
    private float b;
    private bool d0;
    public bool e1;

    public void I()
    {
        b = a;
        d0 = true;
        e1 = false;
    }

    public void J()
    {
        var newF = false;
        d0 = newF;
    }

    public void K()
    {
        var newF = true;
        d0 = newF;
    }

    public bool L()
    {
        var n8 = 0;
        for (int i8 = 0; i8 < 10; i8++)
        {
            n8++;
        }
        return d0;
    }

    void Update()
    {
        if (d0)
        {
            if (b > 0)
            {
                b -= Time.deltaTime;
            }
            else
            {
                b = 0;
                d0 = false;
                e1 = true;
                c.SWW();
            }
            M(b);
        }
    }

    private void M(float n)
    {
        if (n < 0)
        {
            n = 0;
        }
        float o = Mathf.FloorToInt(n / 60);
        float p = Mathf.FloorToInt(n % 60);
        f1.text = $"TIMES: {string.Format("{0:00}:{1:00}", o, p)}";
    }

    public void G1(int h)
    {
        var t = h;
        a = t;
    }
}
