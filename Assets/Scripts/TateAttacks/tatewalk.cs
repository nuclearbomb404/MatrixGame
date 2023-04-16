using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class tatewalk : StateMachineBehaviour
{
    public Transform player;
    public AudioClip hurt;
    public NavMeshAgent agent;
    public bool close =false;
    public GameObject head;
    public GameObject minigun;
    public LayerMask WallMask;
    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int LayerIndex)
    {
        minigun = GameObject.FindGameObjectWithTag("minigungun");
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        head = GameObject.FindGameObjectWithTag("head");
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int LayerIndex)
    {
        if(animator.GetBool("secondphase"))
        {
            minigun.GetComponent<MeshRenderer>().enabled = true;
        }
        Vector3 target = new Vector3(player.position.x, player.position.y,player.position.z);
        agent.SetDestination(target);
        if (Vector3.Distance(animator.transform.position, player.position) < 15f && Vector3.Distance(animator.transform.position, player.position) > 6)
        {  
            if(animator.GetBool("secondphase"))
            {
                int att = Random.Range(1, 4);
                close = true;
                agent.SetDestination(animator.transform.position);
                if(att == 1)
                {
                    animator.SetTrigger("attack");
                    att = Random.Range(1, 4);
                }
                if(att == 2)
                {
                    animator.SetTrigger("money");
                    att = Random.Range(1, 4);
                }
                Collider[] hitColliders = Physics.OverlapSphere(animator.transform.position, 3, WallMask);
                    if(att == 3 && hitColliders.Length == 0)
                    {                
                        animator.SetTrigger("bugatti");
                        att = Random.Range(1, 4); 
                    }
            }
            else
            {
                int att = Random.Range(1, 3);
                close = true;
                agent.SetDestination(animator.transform.position);
                if(att == 1)
                {
                    animator.SetTrigger("attack");
                    att = Random.Range(1, 3);
                }
                if(att == 2)
                {
                    animator.SetTrigger("money");
                    att = Random.Range(1, 3);
                }
            }
        }
        else if (Vector3.Distance(animator.transform.position, player.position) < 6)
        {
            close = true;
            agent.SetDestination(animator.transform.position);
            animator.SetTrigger("explode");
        }
        else
        {
            close = false;
        }
        Vector3 lookAtPosition = player.position;
        lookAtPosition.y = animator.transform.position.y;
        animator.transform.LookAt(lookAtPosition);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int LayerIndex)
    {
        animator.ResetTrigger("attack");
    }
    void hurtfunc()
    {
        player.GetComponent<AudioSource>().PlayOneShot(hurt);
        player.GetComponent<health>().hitrecently = true;
        player.GetComponent<health>().StartCoroutine("regen");
        player.GetComponent<health>().hp -= 25;
        player.GetComponent<ParticleSystem>().Play();
    }

}
