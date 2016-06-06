using UnityEngine;
using System.Collections.Generic;

public abstract class BattleElement : MonoBehaviour
{
    public abstract bool isDead { get; set; }

    public abstract GameObject myGameObject { get; set; }

    public Queue<int> QDamage = new Queue<int>();

    public virtual BattleElement battleElement { get { return this; } set { } }

    protected readonly object syncLock = new object();

    public virtual void DoDamage(int damage)
    {
        lock (syncLock)
        {
            if (isDead)
            {
                return;
            }

            QDamage.Enqueue(damage);
        }
    }

    public virtual void Heal(int points)
    {

    }

    public virtual void Stun(int seconds)
    {
        if (isDead)
        {
            return;
        }
    }

    public virtual void Bleeding(double value ,int seconds)
    {
        if (isDead)
        {
            return;
        }
    }

}
