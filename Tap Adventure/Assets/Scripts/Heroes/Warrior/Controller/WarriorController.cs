using UnityEngine;
using System.Collections;

public class WarriorController : BattleElement{

    public WarriorData data;
    public WarriorView view;

    public override bool isDead
    {
        get { return data.isDead; }
        set { data.isDead = value; }
    }

    public override GameObject myGameObject
    {
        get { return view.gameObject; }
        set { myGameObject = value; }
    }

    public override BattleElement target
    {
        get { return data.target; }
        set { data.target = value; }
    }

    void Start()
    {
        data.Init();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lock (syncLockD)
        {
            if (!data.isDead)
            {
                if (qDamage.Count > 0)
                {
                    data.life -= qDamage.Dequeue();
                    if (data.life <= 0)
                    {
                        data.isDead = true;
                        data.life = 0;
                    }
                }
            }
        }

        lock (syncLockH)
        {
            if (!data.isDead)
            {
                if (qDamage.Count > 0)
                {
                    data.life += qHealth.Dequeue();
                    if (data.life > data.health.value)
                    {
                        data.life += (int)data.health.value;
                    }
                }
            }
        }
                

        if (!data.isAttack)
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
        if (!data.isDead)
        {
            while (!enemy.isDead)
            {
                if (Random.Range(0.00f,1.00f) <= data.crit.value)
                {
                    Debug.Log("critical");
                    enemy.DoDamage((int)data.attack.value2 * 2);
                }
                else
                {
                    enemy.DoDamage(Random.Range((int)data.attack.value, (int)data.attack.value2));
                }

                yield return new WaitForSeconds((int)data.speed.value);
            }

            yield return null;
        }
        else
        {
            data.target = null;
        }
    }

    public override void DoDamage(int damage)
    {
        base.DoDamage(damage);
    }

    public override void Heal(int points)
    {
        base.Heal(points);
    }
}
