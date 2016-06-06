using UnityEngine;
using System.Collections.Generic;

public class EnemyPoolData : MonoBehaviour {

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
    void Start () {
        GameObject enemy;
        enemyPool = new Queue<GameObject>();

        foreach (GameObject item in enemyForest)
        {
            //item.SetActive(false);
            enemy = Instantiate(item);
            enemyPool.Enqueue(enemy);
        }

        target = enemyPool.Dequeue();
        battleElementTarget = target.GetComponent<BattleInterface>().battleElement;
        target.SetActive(true);
        target.transform.GetChild(0).gameObject.GetComponent<EnemyData>().target = warrior;
        warriorData.target = battleElementTarget;
        rogueData.target = battleElementTarget;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
