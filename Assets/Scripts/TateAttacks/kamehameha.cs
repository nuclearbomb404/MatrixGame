using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kamehameha : StateMachineBehaviour
{
    public Transform player;
    public ParticleSystem laser, laserinstance;
    public LayerMask playermask;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        laser =  GameObject.FindGameObjectWithTag("laser").GetComponent<ParticleSystem>();
        if(animator.GetBool("secondphase"))
        {
            animator.speed = 05f;
        }
        player = GameObject.FindGameObjectWithTag("Player").transform;
        laser.transform.LookAt(player);
        laserinstance = Instantiate(laser,laser.transform.position, laser.transform.rotation);
        laserinstance.Play();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
        animator.ResetTrigger("attack");
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {        
        //float rInt = Random.Range(-0.5f,0.5f);
        //Vector3 Delay = new Vector3(player.position.x -rInt,player.position.y,player.position.z - rInt);
        laserinstance = Instantiate(laser,laser.transform.position, laser.transform.rotation);
        laserinstance.Play();
        animator.speed = 01f;
    }
    

}
