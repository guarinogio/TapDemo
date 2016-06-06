using UnityEngine;
using System.Collections.Generic;

public abstract class BattleElement : MonoBehaviour
{
    public abstract bool isDead { get; set; }

    public abstract GameObject myGameObject { get; set; }

    public Queue<int> qDamage = new Queue<int>();
    public Queue<int> qHealth = new Queue<int>();

    public virtual BattleElement battleElement { get { return this; } set { } }

    protected readonly object syncLockD = new object();
    protected readonly object syncLockH = new object();

    public virtual void DoDamage(int damage)
    {
        lock (syncLockD)
        {
            if (isDead)
            {
                return;
            }

            qDamage.Enqueue(damage);
        }
    }

    public virtual void Heal(int points)
    {
        lock (syncLockH)
        {
            if (isDead)
            {
                return;
            }

            qHealth.Enqueue(points);
        }
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
