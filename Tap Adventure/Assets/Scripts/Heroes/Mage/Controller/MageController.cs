using UnityEngine;
using System.Collections;

public class MageController : BattleElement{

    public MageData data;
    public MageView view;

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
        if(!data.isAttack)
        {
            if (data.target != null)
            {
                data.isAttack = true;
                StartCoroutine(Heal(data.target));
            }
        }
    }

    public IEnumerator Heal(BattleElement enemy)
    {
        if (!data.isDead)
        {
            while (!enemy.isDead)
            {
                if (Random.Range(0.00f,1.00f) <= data.will.value)
                {
                    enemy.Heal(new SkillValue((int)data.power.value2 * 2,true));
                }
                else
                {
                    enemy.Heal(new SkillValue(Random.Range((int)data.power.value, (int)data.power.value2)));
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
