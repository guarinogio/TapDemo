using UnityEngine;
using System.Collections;
public class TimedObjectDestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void DestroyNow()
    {
        Destroy(this.gameObject);
    }

    public void DestroyAfter(float seconds)
    {
        Invoke("DestroyNow", seconds);
    }
}
