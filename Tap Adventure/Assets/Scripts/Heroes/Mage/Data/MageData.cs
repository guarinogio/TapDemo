using UnityEngine;
using System.Collections;

public class MageData : MonoBehaviour {

    public Attribute power;
    public Attribute speed;
    public Attribute will;

    public bool isDead;
    public bool isAttack;

    public BattleElement target;

    // Use this for initialization
    void Start () {
        power = new Attribute(ATTRIBUTE_TYPE.POWER,20,50,100,100);
        power.SetFormula(ATTRIBUTE_FORMULA.FUNTION4, 10, 15, 100, 200);
        speed = new Attribute(ATTRIBUTE_TYPE.SPEED, 1);
        will = new Attribute(ATTRIBUTE_TYPE.WILL, 0.3f);
    }
	
    public void lvlup()
    {
        will.Buy(100);
        Debug.Log(will.value);
    }
}
