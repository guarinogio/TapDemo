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
        validateButtons();
        SetEnemy();
        view.SetRound(data.round, data.enemyPool.Count);
    }

    public void validateButtons()
    {
        if (data.level <= 1)
        {
            view.backButton.SetActive(false);
        }
        else
        {
            view.backButton.SetActive(true);
        }


        if (data.level >= data.MaxLevel)
        {
            view.nextButton.SetActive(false);
        }
        else
        {
            view.nextButton.SetActive(true);
        }
    }

    public void Next()
    {
        data.target.SetActive(false);
        data.enemyPool.Enqueue(data.target);
        SetEnemy();
        if (data.level == data.MaxLevel)
        {
            if (!data.roundKey)
            {
                if (data.round <= data.enemyPool.Count)
                {
                    data.round++;
                }
            }
        }
        validateRound();
        Debug.Log("new enemy");
    }

    private void validateRound()
    {
        if (data.level == data.MaxLevel)
        {
            view.roundText.SetActive(true);
            if (data.roundKey)
            {
                data.round = 1;
                data.roundKey = false;
                view.roundText.SetActive(true);
                view.SetRound(data.round, data.enemyPool.Count);

            }
            else
            {
                if (data.round <= data.enemyPool.Count)
                {
                    view.SetRound(data.round, data.enemyPool.Count);
                }
                else
                {
                    view.roundText.SetActive(false);
                    if (!data.roundKey)
                    {
                        data.roundKey = true;
                        data.MaxLevel++;
                    }

                    validateButtons();
                }
            }
        }
        else
        {
            view.roundText.SetActive(false);
        }


    }

    public void SetEnemy()
    {
        int j = UnityEngine.Random.Range(1,data.enemyPool.Count);
        for (int i = 0; i < j-1; i++)
        {
            data.enemyPool.Enqueue(data.enemyPool.Dequeue());
        }
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
            validateButtons();
            validateRound();
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
            validateButtons();
            validateRound();
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
