using UnityEngine;
using System.Collections;

public class EnemyView : MonoBehaviour {

    public GameObject enemy;
    Animator animController;

    void Awake()
    {
        animController = enemy.GetComponent<Animator>();
    }
    public void TriggerDamage()
    {
        if (Random.Range(0, 10)>3)
        {
            animController.SetTrigger("Take Damage");
        }
    }

    public void TriggerAttack()
    {
        switch(Random.Range(0, 10))
        {
            case 0:
                animController.SetTrigger("Jump Attack");
                break;
            case 1:
                animController.SetTrigger("Double Attack");
                break;
            default:
                if(Random.Range(0, 10) > 4)
                    animController.SetTrigger("Slash Attack 01");
                else
                    animController.SetTrigger("Slash Attack 02");
                break;
        }
    }


    public void TriggerDead()
    {
        Debug.Log("TriggerDead");
        animController.SetBool("Dead", true);
    }
    public void TriggerStun()
    {
        animController.SetTrigger("Upset");
    }
}
