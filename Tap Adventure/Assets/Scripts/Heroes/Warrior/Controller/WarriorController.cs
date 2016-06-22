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
                    int d = qDamage.Dequeue();
                    data.life -= d;
                    view.UpdateHPBar((float)data.life / (float)data.health.value);
                    GameObject go = (GameObject)Instantiate(FloatText, transform.position + Vector3.up * 0.5f, Quaternion.identity);
                    go.GetComponent<FloatingTextController>().InitText(Color.red, d.ToString(), FloatingTextController.FloatTextType.ForceRight);
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
                    int d = qHealth.Dequeue();
                    data.life += d;
                    view.UpdateHPBar((float)data.life / (float)data.health.value);
                    GameObject go = (GameObject)Instantiate(FloatText, transform.position + Vector3.up * 0.5f, Quaternion.identity);
                    go.GetComponent<FloatingTextController>().InitText(Color.green, d.ToString(), FloatingTextController.FloatTextType.Up);
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
                    Debug.Log("critical");
                    enemy.DoDamage((int)data.attack.value2 * 2);
                }
                else
                {
                    enemy.DoDamage(Random.Range((int)data.attack.value, (int)data.attack.value2));
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

    public override void DoDamage(int damage)
    {
        base.DoDamage(damage);
    }

    public override void Heal(int points)
    {
        base.Heal(points);
    }
}
