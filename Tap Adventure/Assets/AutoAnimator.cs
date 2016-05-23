using UnityEngine;
using System.Collections;

public class AutoAnimator : MonoBehaviour {
	public string animstr;
	Animator anim_ctrl;
	float lastaction;
	float nextaction;
	public float min;
	public float max;
	public bool requiresExit = true;
	// Use this for initialization
	void Start () {
		lastaction = Time.time;
		nextaction = lastaction + Random.Range (min, max);
		anim_ctrl = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > nextaction) {
			lastaction = Time.time;
			nextaction = lastaction + Random.Range (min, max);
			anim_ctrl.SetTrigger (animstr);
			if (requiresExit)
				Invoke ("ExitAnim", 1);
		}
	}

	void ExitAnim(){
		anim_ctrl.SetTrigger (animstr);
	}
}
