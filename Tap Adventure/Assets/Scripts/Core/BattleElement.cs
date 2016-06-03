using UnityEngine;
using System.Collections;

public abstract class BattleElement : MonoBehaviour
{
    public abstract bool isDead { get; set; }

    public abstract GameObject myGameObject { get; set; }

    public virtual BattleElement battleElement { get { return this; } set { } }

    public virtual void DoDamage(int damage)
    {
        if (isDead)
        {
            return;
        }
    }

    public virtual void Heal(int points)
    {

    }
}
