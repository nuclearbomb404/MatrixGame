using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moneyatt : StateMachineBehaviour
{
    public GameObject player, money;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        money = GameObject.Find("money");
        player = GameObject.FindGameObjectWithTag("Player");
        if(!animator.GetBool("secondphase"))
        {
            money.transform.GetChild(1).gameObject.SetActive(true);
            money.transform.GetChild(2).gameObject.SetActive(false);
        }
        if(animator.GetBool("secondphase"))
        {
            money.transform.GetChild(1).gameObject.SetActive(false);
            money.transform.GetChild(2).gameObject.SetActive(true);
            animator.speed = 05f;
        }

        animator.GetComponent<NavMeshAgent>().SetDestination(animator.transform.position);
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("money");
        animator.speed = 01f;
        Vector3 summonlocation = new Vector3(player.transform.position.x,player.transform.position.y +15,player.transform.position.z);
        Instantiate(money,summonlocation, money.transform.rotation);
    }

}
