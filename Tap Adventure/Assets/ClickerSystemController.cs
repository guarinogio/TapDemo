using UnityEngine;
using System.Collections;

public class ClickerSystemController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public void ClickHeal () {
        WarriorController.Instance.Heal(new SkillValue(10));
	}
    public void ClickAttack()
    {
        EnemyPoolController.Instance.data.battleElementTarget.DoDamage(new SkillValue(10));
    }
}
