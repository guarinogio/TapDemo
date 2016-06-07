using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class EnemyController : BattleElement {

    public EnemyData data;
    public EnemyView view;

    public override bool isDead
    {
        get{ return data.isDead;}
        set{ data.isDead = value;}
    }

    public override GameObject myGameObject
    {
        get{return view.gameObject;}
        set {myGameObject = value;}
    }

    public override BattleElement target
    {
        get { return data.target; }
        set { data.target = value; }
    }

    // Use this for initialization
    void Start()
    {
        data.Init();
    }

    void FixedUpdate()
    {
        lock (syncLockD)
        {
            if (!data.isDead && qDamage.Count > 0)
            {
                data.life -= qDamage.Dequeue();
                if (data.life <= 0)
                {
                    data.isDead = true;
                    data.life = 0;
                }
            }
        }

        if (!data.isDead && !data.isAttack)
        {
            if (data.target != null)
            {
                data.isAttack = true;
                StartCoroutine(Attack(data.target));
            }
        }
    }

    public IEnumerator Attack(BattleElement enemy)
    {
        if (!data.isDead && !data.isStunned)
        {
            while (!enemy.isDead)
            {
                if (data.target != null)
                {
                    enemy.DoDamage((int)data.attack.value);
                }
                yield return new WaitForSeconds((float)data.speed.value);
            }

            yield return null;
        }
        else
        {
            data.target = null;
        }
    }

    public IEnumerator StunMe(int seconds)
    {
        data.isStunned = true;
        yield return new WaitForSeconds((float)seconds);
        data.isStunned = false;
    }

    public IEnumerator BleedingMe(double value, int seconds)
    {
        data.isBleeding = true;
        for (int i = 0; i < 3; i++)
        {
            if (data.life > 0)
            {
                DoDamage((int)value);
                yield return new WaitForSeconds((float)seconds);
            }
            else
            {
                break;
            }
        }
        data.isBleeding = false;
    }

    public override void DoDamage(int damage)
    {
            base.DoDamage(damage);
    }

    public override void Stun(int seconds)
    {
        base.Stun(seconds);
        StartCoroutine(StunMe(seconds));
    }

    public override void Bleeding(double value, int seconds)
    {
        base.Bleeding(value, seconds);
        StartCoroutine(BleedingMe(value,seconds));
    }
}
