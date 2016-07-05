using UnityEngine;
using System.Collections.Generic;

public class EnemyPoolData : MonoBehaviour
{

    public int level;
    public int MaxLevel;

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

    public List<GameObject> boss;
    public List<GameObject> miniBoss;

    public List<string> names;

    public GameObject target;
    public BattleElement battleElementTarget;

    public BattleElement warrior;

    // Use this for initialization
    public void Init()
    {
        List<GameObject> pivot;

        round = 1;
        roundKey = false;
        enemyPool = new Queue<GameObject>();
        garbageQueue = new Queue<GameObject>();
        enemyList = new List<List<GameObject>> { one, new List<GameObject> { miniBoss[0] }, one, new List<GameObject> { boss[0] } , two, new List<GameObject> { miniBoss[1] }, two, new List<GameObject> { boss[1] }, three, new List<GameObject> { miniBoss[2] }, three, new List<GameObject> { boss[2] }, four, new List<GameObject> { miniBoss[3] }, four, new List<GameObject> { boss[3] }, five, new List<GameObject> { miniBoss[4] }, five, new List<GameObject> { boss[4] }, six, new List<GameObject> { miniBoss[5] }, six, new List<GameObject> { boss[5] }, seven, new List<GameObject> { miniBoss[6] }, seven, new List<GameObject> { boss[6] }, eight, new List<GameObject> { miniBoss[7] }, eight, new List<GameObject> { boss[7] }, nine, new List<GameObject> { miniBoss[8] }, nine, new List<GameObject> { boss[8] }, ten, new List<GameObject> { miniBoss[9] }, ten, new List<GameObject> { boss[9] } };
    }


}
