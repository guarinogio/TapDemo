using UnityEngine;
using System.Collections;

public class RogueController : BattleElement{

    public RogueData data;
    public RogueView view;

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

    // Use this for initialization
    void Start()
    {
        data.Init();
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
                if (Random.Range(0,2) == 0)
                {
                    enemy.Stun((int)data.stun.value);
                }
                else
                {
                    enemy.Bleeding(Random.Range((int)data.bleeding.value, (int)data.bleeding.value2),(int)data.potency.value);
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
}
