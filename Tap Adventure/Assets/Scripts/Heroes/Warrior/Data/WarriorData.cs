using UnityEngine;
using System.Collections;

public class WarriorData : MonoBehaviour {

    public int MaxLife;
    public Attribute attack;
    public Attribute speed;
    public Attribute health;
    public Attribute crit;

    public int life;
    public bool isDead;
    public bool isAttack;


    // Use this for initialization
    void Start () {
        life = MaxLife;
        attack = new Attribute(ATTRIBUTE_TYPE.ATTACK);
        speed = new Attribute(ATTRIBUTE_TYPE.SPEED);
        health = new Attribute(ATTRIBUTE_TYPE.HEALTH);
        crit = new Attribute(ATTRIBUTE_TYPE.CRIT);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
