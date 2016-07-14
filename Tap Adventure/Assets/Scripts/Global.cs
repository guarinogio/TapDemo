using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Global :  Singleton<Global>{

    private Queue<int> qGold = new Queue<int>();
    private Queue<int> qGems = new Queue<int>();

    protected readonly object syncLockGold = new object();
    protected readonly object syncLockGems = new object();

    private int _gold;
    private int _gems;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        lock (syncLockGold)
        {
            if (qGold.Count > 0)
            {
                int d = qGold.Dequeue();
                _gold += d;
            }
        }

        lock (syncLockGems)
        {
            if (qGems.Count > 0)
            {
                int d = qGems.Dequeue();
                _gems += d;
            }
        }
    }

    public int GetGold()
    {
        lock (syncLockGold)
        {
            return _gold;
        }
    }

    public int GetGems()
    {
        lock (syncLockGems)
        {
            return _gems;
        }
    }

    public void AddGold(int gold)
    {
        lock (syncLockGold)
        {
            qGold.Enqueue(gold);
        }
    }

    public void AddGems(int gems)
    {
        lock (syncLockGems)
        {
            qGems.Enqueue(gems);
        }
    }

    public string DoubletoString(double _value)
    {
        VALUE_PRECISION precision = VALUE_PRECISION.NONE;

        if(_value < 0)
        {
            _value *= -1;
        }

        while (_value > 1000)
        {
            precision++;
            _value /= 1000;
        }

        _value = (int)_value;

        string text = _value.ToString();

        if (precision > 0)
        {
            text += precision.ToString();
        }

        return text;
    }
}
