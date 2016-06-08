using UnityEngine;
using System.Collections;

public class EnemyPoolController : MonoBehaviour {

    public EnemyPoolData data;
    public EnemyPoolController me;

    // Use this for initialization
    void Start () {
        data.Init();
        Init();
	}

    void Init()
    {
        GameObject enemy;

        foreach (GameObject item in data.enemyForest)
        {
            //item.SetActive(false);
            enemy = Instantiate(item);
            data.enemyPool.Enqueue(enemy);
        }

        SetEnemy();
    }

    public void Next()
    {
        data.target.SetActive(false);
        data.enemyPool.Enqueue(data.target);
        SetEnemy();
        Debug.Log("new enemy");
    }


    public void SetEnemy()
    {
        data.target = data.enemyPool.Dequeue();
        data.battleElementTarget = data.target.GetComponent<BattleInterface>().battleElement;
        data.battleElementTarget.Init();
        data.battleElementTarget.Reset();
        data.target.SetActive(true);
        data.warriorData.target = data.battleElementTarget;
        data.rogueData.target = data.battleElementTarget;
        data.target.GetComponent<BattleInterface>().battleElement.target = data.warrior;
    }

	// Update is called once per frame
	void Update () {
	
	}
}
