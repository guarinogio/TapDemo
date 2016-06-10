using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyPoolView : MonoBehaviour {

    public Text level;
    public Text world;
    public Button back;
    public Button next;
    public GameObject backButton;
    public GameObject nextButton;

    public void SetLevel(int level)
    {
        this.level.text = level.ToString();
    }

    public void SetWorld(string name)
    {
        this.world.text = name;
    }
}
