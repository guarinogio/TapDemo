using UnityEngine;
using System.Collections.Generic;

public class EnemyPoolData : MonoBehaviour
{

    public int level = 1;

    public WarriorData warriorData;
    public RogueData rogueData;
    public EnemyData enemyData;
    public EnemyController enemyController;
    public EnemyView enemyView;

    public Queue<GameObject> enemyPool;

    public List<GameObject> enemyForest;

    public GameObject target;
    public BattleElement battleElementTarget;

    public BattleElement warrior;

    // Use this for initialization
    public void Init()
    {
        enemyPool = new Queue<GameObject>();
    }


}
