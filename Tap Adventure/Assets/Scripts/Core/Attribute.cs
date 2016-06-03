using UnityEngine;
using System.Collections;
using System;

public class Attribute{

    private ATTRIBUTE_TYPE type;
    private int cost;
    private int lvl;
    private int value;

    public Attribute(ATTRIBUTE_TYPE type)
    {
        this.type = type;
        cost = 100;
        lvl = 1;
        value = 50;
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
