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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!data.isAttack)
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
        data.life -= damage;
        if (data.life <= 0)
        {
            data.isDead = true;
            data.life = 0;
        }
    }

    public override void Heal(int points)
    {
        base.Heal(points);
        if (!data.isDead)
        {
            data.life += points;
            if (data.life > data.health.value)
            {
                data.life = (int)data.health.value;
            }
        }
    }
}
