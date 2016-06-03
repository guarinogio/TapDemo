using UnityEngine;
using System.Collections;
using System;

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

    // Use this for initialization
    void Start () {
	
	}

    void FixedUpdate()
    {
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
            while (!enemy.isDead) {
                enemy.DoDamage((int)data.attack.value);
                yield return new WaitForSeconds(data.speed.value);
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
        if(data.life <= 0)
        {
            data.isDead = true;
            data.life = 0;
        } 
    }
}
