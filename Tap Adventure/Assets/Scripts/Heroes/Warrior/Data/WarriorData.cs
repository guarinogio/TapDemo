using UnityEngine;
using System.Collections;

public class WarriorData : MonoBehaviour {

    public Attribute attack;
    public Attribute speed;
    public Attribute health;
    public Attribute crit;

    public int life;
    public bool isDead;
    public bool isAttack;

    public BattleElement target;

    // Use this for initialization
    public void Init () {
        /*
        attack = new Attribute(ATTRIBUTE_TYPE.ATTACK,20,50,100,100);
        attack.SetFormula(ATTRIBUTE_FORMULA.FUNTION4, 10, 15, 100, 200);
        */

        attack = new Attribute(ATTRIBUTE_TYPE.ATTACK, 20, 50, 100, 100);
        attack.SetFormula(ATTRIBUTE_FORMULA.FUNTION3, 1, 1);

        speed = new Attribute(ATTRIBUTE_TYPE.SPEED, 1, 1, 150, 50);
        speed.SetFormula(ATTRIBUTE_FORMULA.FUNTION3, 2, 1.5);

        health = new Attribute(ATTRIBUTE_TYPE.HEALTH, 500, 500, 125, 200);
        health.SetFormula(ATTRIBUTE_FORMULA.FUNTION3, 1, 1.5);

        crit = new Attribute(ATTRIBUTE_TYPE.CRIT, 0.3f, 0.3f, 200, 50);
        crit.SetFormula(ATTRIBUTE_FORMULA.FUNTION3, 0.5, 1.5);

        life = (int)health.value;
    }
	
    public void lvlup()
    {
        attack.Buy(100);
        Debug.Log(attack.value);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
