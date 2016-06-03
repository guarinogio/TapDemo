using UnityEngine;
using System.Collections;

public class Buffer
{
    private Attribute target;
    private int cooldown;
    private int duration;
    private int multiplier;

    public Buffer(int cooldown, int duration, int multiplier)
    {
        this.cooldown = cooldown;
        this.duration = duration;
        this.multiplier = multiplier;
    }

    public void Buff(Attribute target)
    {

    }
}
