using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WarriorView : MonoBehaviour {

    public GameObject warrior;
    public Image HealthBar;

    public void UpdateHPBar(float hp)
    {
        hp = Mathf.Clamp01(hp);
        HealthBar.fillAmount = hp;
    }

}
