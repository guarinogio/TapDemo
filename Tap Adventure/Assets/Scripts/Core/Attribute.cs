using UnityEngine;
using System.Collections;
using System;

public class Attribute{

    private ATTRIBUTE_TYPE type;
    private int cost;
    private int lvl;
    public float value { get; private set; }

    public Attribute(ATTRIBUTE_TYPE type, float value)
    {
        this.type = type;
        cost = 100;
        lvl = 1;
        this.value = value;
    }

    public bool Buy(int coins)
    {
        if (coins >= cost)
        {
            LvlUP();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void LvlUP()
    {
        lvl++;
        value++;
        cost++;
    }
}
