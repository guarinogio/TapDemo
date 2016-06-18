using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyPoolView : MonoBehaviour {

    public Text level;
    public Text world;
    public Text round;
    public Button back;
    public Button next;
    public GameObject backButton;
    public GameObject nextButton;
    public GameObject roundText;

    public void SetLevel(int level)
    {
        this.level.text = level.ToString();
    }

    public void SetWorld(string name)
    {
        this.world.text = name;
    }

    public void SetRound(int level, int maxLevel)
    {
        if(level <= maxLevel)
        {
            this.round.text = level.ToString() + "/" + (maxLevel+1).ToString();
        }

    }
}
