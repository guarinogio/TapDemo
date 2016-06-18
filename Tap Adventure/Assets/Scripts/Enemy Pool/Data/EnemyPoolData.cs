using UnityEngine;
using System.Collections.Generic;

public class EnemyPoolData : MonoBehaviour
{

    public int level;
    public int MaxLevel;

    [HideInInspector]
    public int round;
    [HideInInspector]
    public bool roundKey;

    public WarriorData warriorData;
    public RogueData rogueData;

    public Queue<GameObject> enemyPool;

    public Queue<GameObject> garbageQueue;

    public List<List<GameObject>> enemyList;

    public int index = 0;

    public List<GameObject> one;
    public List<GameObject> two;
    public List<GameObject> three;
    public List<GameObject> four;
    public List<GameObject> five;
    public List<GameObject> six;
    public List<GameObject> seven;
    public List<GameObject> eight;
    public List<GameObject> nine;
    public List<GameObject> ten;

    public List<string> names;

    public GameObject target;
    public BattleElement battleElementTarget;

    public BattleElement warrior;

    // Use this for initialization
    public void Init()
    {
        round = 1;
        roundKey = false;
        enemyPool = new Queue<GameObject>();
        garbageQueue = new Queue<GameObject>();
        enemyList = new List<List<GameObject>>();
        enemyList.Add(one);
        enemyList.Add(two);
        enemyList.Add(three);
        enemyList.Add(four);
        enemyList.Add(five);
        enemyList.Add(six);
        enemyList.Add(seven);
        enemyList.Add(eight);
        enemyList.Add(nine);
        enemyList.Add(ten);
    }


}
