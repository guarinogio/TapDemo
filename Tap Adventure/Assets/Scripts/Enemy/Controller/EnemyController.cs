using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class EnemyController : BattleElement {
    public GameObject FloatText;
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

    public override void Init()
    {
        base.Init();
        data.Init();
    }

    void FixedUpdate()
    {
        lock (syncLockD)
        {
            if (!data.isDead && qDamage.Count > 0)
            {
                SkillValue d = qDamage.Dequeue();
                data.life -= d.Value();
                EnemyPoolController.Instance.view.UpdateHPBar((float)data.life / (float)data.health.value);
                GameObject go = (GameObject)Instantiate(FloatText, transform.position + Vector3.up * 0.5f, Quaternion.identity);

                if (d.IsCritical())
                {
                    go.GetComponent<FloatingTextController>().InitText(Color.yellow, d.Value().ToString(), FloatingTextController.FloatTextType.ForceLeft);
                }
                else
                {
                    go.GetComponent<FloatingTextController>().InitText(Color.red, d.Value().ToString(), FloatingTextController.FloatTextType.ForceLeft);
                }

                if (data.life <= 0)
                {
                    data.isDead = true;
                    data.life = 0;
                    kill();
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

    private void kill()
    {
        view.TriggerDead();
        data.pool.Next();
    }

    public override void Reset()
    {
        base.Reset();
        data.Reset();
    }

    public IEnumerator Attack(BattleElement enemy)
    {
        if (!data.isDead && !data.isStunned)
        {
            while (!enemy.isDead)
            {
                view.TriggerAttack();
                if (data.target != null)
                {
                    enemy.DoDamage(new SkillValue((int)data.attack.value));
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
                DoDamage(new SkillValue((int)value));
                yield return new WaitForSeconds((float)seconds);
            }
            else
            {
                break;
            }
        }
        data.isBleeding = false;
    }

    public override void DoDamage(SkillValue damage)
    {
        view.TriggerDamage();
        base.DoDamage(damage);
    }

    public override void Stun(int seconds)
    {
        base.Stun(seconds);
        view.TriggerStun();
        StartCoroutine(StunMe(seconds));
    }

    public override void Bleeding(double value, int seconds)
    {
        base.Bleeding(value, seconds);
        StartCoroutine(BleedingMe(value,seconds));
    }
}
