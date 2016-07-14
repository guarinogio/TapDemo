using UnityEngine;
using System.Collections;

public class WarriorController : BattleElement{
    public GameObject FloatText;
    public static WarriorController Instance;
    public WarriorData data;
    public WarriorView view;

    void Awake()
    {
        Instance = this;
    }
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
                    SkillValue d = qDamage.Dequeue();
                    data.life -= (int)d.Value();
                    view.UpdateHPBar((float)data.life / (float)data.health.value);
                    GameObject go = (GameObject)Instantiate(FloatText, transform.position + Vector3.up * 0.5f, Quaternion.identity);

                    if (d.GetAttType() == ATTACK_TYPE.CRITICAL)
                    {
                        go.GetComponent<FloatingTextController>().InitText(Color.yellow, Global.Instance.DoubletoString(d.Value()), FloatingTextController.FloatTextType.ForceRight);
                    }
                    else
                    {
                        go.GetComponent<FloatingTextController>().InitText(Color.red, Global.Instance.DoubletoString(d.Value()), FloatingTextController.FloatTextType.ForceRight);
                    }

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
                if (qHealth.Count > 0)
                {
                    SkillValue d = qHealth.Dequeue();
                    data.life += (int)d.Value();
                    view.UpdateHPBar((float)data.life / (float)data.health.value);
                    GameObject go = (GameObject)Instantiate(FloatText, transform.position + Vector3.up * 0.5f, Quaternion.identity);

                    if (d.GetAttType() == ATTACK_TYPE.HEAL_CRITICAL)
                    {
                        go.GetComponent<FloatingTextController>().InitText(Color.cyan, Global.Instance.DoubletoString(d.Value()), FloatingTextController.FloatTextType.Up);
                    }
                    else
                    {
                        go.GetComponent<FloatingTextController>().InitText(Color.green, Global.Instance.DoubletoString(d.Value()), FloatingTextController.FloatTextType.Up);
                    }


                    if (data.life > data.health.value)
                    {
                        data.life = (int)data.health.value;
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
                    enemy.DoDamage(new SkillValue((int)data.attack.value2 * 2, ATTACK_ELEMENT.WARRIOR, ATTACK_TYPE.CRITICAL));
                }
                else
                {
                    enemy.DoDamage(new SkillValue( Random.Range((int)data.attack.value, (int)data.attack.value2), ATTACK_ELEMENT.WARRIOR, ATTACK_TYPE.BASIC)  );
                }

                yield return new WaitForSeconds((int)data.speed.value);
            }

            data.isAttack = false;
            yield return null;
        }
        else
        {
            data.target = null;
        }
    }

    public override void DoDamage(SkillValue damage)
    {
        base.DoDamage(damage);
    }

    public override void Heal(SkillValue points)
    {
        base.Heal(points);
    }
}
