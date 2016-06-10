using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemyPoolController : MonoBehaviour {

    public EnemyPoolData data;
    public EnemyPoolController me;
    public EnemyPoolView view;

    // Use this for initialization
    void Start () {
        data.Init();
        Init();
	}

    void Init()
    {

        view.next.onClick.AddListener(nextLevel);
        view.back.onClick.AddListener(lastLevel);

        GameObject enemy;

        List<GameObject> enemyList = data.enemyList[data.index++];

        foreach (GameObject item in enemyList)
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


    public void nextLevel()
    {
        if (data.level < data.MaxLevel)
        {
            data.level++;
            view.SetLevel(data.level);
        }

        if(data.level%10 == 0)
        {
            SetNewWorld(true);
        }
    }

    public void lastLevel()
    {
        if (data.level > 1)
        {
            data.level--;
            view.SetLevel(data.level);
        }

        if (data.level % 10 == 0)
        {
            SetNewWorld(false);
        }
    }

    public void SetNewWorld(bool isNext)
    {
        List<GameObject> enemyList;
        GameObject enemy;

        if (isNext)
        {
            enemyList = data.enemyList[data.index++];
        }
        else
        {
            enemyList = data.enemyList[data.index--];
        }

        clearEnemyPool();
//        Debug.Log(enemyList.Count);
//        Debug.Log(data.enemyPool.Count);
//       Debug.Log(data.garbageQueue.Count);
        foreach (GameObject item in enemyList)
        {
            enemy = Instantiate(item);
            data.enemyPool.Enqueue(enemy);
        }

        data.target.GetComponentInChildren<EnemyData>().isDead = true;
        data.target.SetActive(false);
        SetEnemy();
        view.SetWorld(data.names[data.index]);
    }

    private void clearEnemyPool()
    {
        while (data.enemyPool.Count > 0)
        {
            data.garbageQueue.Enqueue(data.enemyPool.Dequeue());
        }

        StartCoroutine(FreeMemo());
    }

    // Update is called once per frame
    void Update ()
    {

	}

    private IEnumerator FreeMemo()
    {
        while(data.garbageQueue.Count > 0)
        {
            Debug.Log(data.garbageQueue.Count);
            Destroy(data.garbageQueue.Dequeue());
            yield return new WaitForSeconds(2);
        }

        yield return null;
    }
}
