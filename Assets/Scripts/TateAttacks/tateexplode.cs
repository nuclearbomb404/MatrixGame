using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class tateexplode : StateMachineBehaviour
{
    public ParticleSystem explosion, explosioninstance;
    public LayerMask PlayerMask;
    public GameObject tate;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        explosion =  GameObject.FindGameObjectWithTag("explosion").GetComponent<ParticleSystem>();
        tate = GameObject.Find("tate");
        tate.GetComponent<NavMeshAgent>().isStopped = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        explosioninstance = Instantiate(explosion,explosion.transform.position, explosion.transform.rotation);
        explosioninstance.Play();
        animator.ResetTrigger("explode");
        Collider[] explosionColliders = Physics.OverlapSphere(animator.transform.position, 10, PlayerMask);
        foreach (var hitCollider in explosionColliders)
        {
            if(hitCollider.name == "Player")
            {
                hitCollider.GetComponent<health>().hp -=100;
            }
        }
        tate.GetComponent<NavMeshAgent>().isStopped = false;
    }

}
