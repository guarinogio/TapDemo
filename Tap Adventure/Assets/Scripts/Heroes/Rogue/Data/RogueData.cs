using UnityEngine;
using System.Collections;

public class RogueData : MonoBehaviour {

    public Attribute stun;
    public Attribute speed;
    public Attribute bleeding;
    public Attribute potency;

    public bool isDead;
    public bool isAttack;

    public BattleElement target;

    // Use this for initialization
    void Start () {
        stun = new Attribute(ATTRIBUTE_TYPE.STUN, 3);
        speed = new Attribute(ATTRIBUTE_TYPE.SPEED, 1);
        bleeding = new Attribute(ATTRIBUTE_TYPE.BLEEDING, 30);
        potency = new Attribute(ATTRIBUTE_TYPE.POTENCY, 1.1f);
    }
}
