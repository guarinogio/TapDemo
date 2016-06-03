using UnityEngine;
using System.Collections;

public class WarriorController : MonoBehaviour {

    public WarriorData data;
    public WarriorView view;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public IEnumerator Attack()
    {
        yield return null;
    }
}
