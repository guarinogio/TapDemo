using UnityEngine;
using System.Collections;

public class EnemyData : MonoBehaviour {

    public Attribute attack;
    public Attribute speed;
    public Attribute health;
    public Attribute crit;

    public int life;
    public bool isDead;
    public bool isAttack;
    public bool isStunned;
    public bool isBleeding;


    public BattleElement target;


    // Use this for initialization
    public void Init()
    {
        attack = new Attribute(ATTRIBUTE_TYPE.ATTACK, 10);
        speed = new Attribute(ATTRIBUTE_TYPE.SPEED, 1);
        health = new Attribute(ATTRIBUTE_TYPE.HEALTH, 1000000);
        crit = new Attribute(ATTRIBUTE_TYPE.CRIT, 0);
        life = (int)health.value;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
