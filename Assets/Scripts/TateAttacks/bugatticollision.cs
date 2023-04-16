using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class bugatticollision : MonoBehaviour
{
    public Transform player;
    public LayerMask WallMask;
    void Start()
    {
    }
    void Update()
    {
        if(transform.parent.GetComponent<Animator>().GetBool("secondphase"))
        {
            transform.parent.GetComponent<NavMeshAgent>().speed = 200;
            transform.parent.GetComponent<NavMeshAgent>().angularSpeed = 200;
            transform.parent.GetComponent<NavMeshAgent>().acceleration = 75;
            transform.parent.GetComponent<NavMeshAgent>().SetDestination(player.position);
        }
        Collider[] hitColliders = Physics.OverlapSphere(transform.parent.transform.position, 5, WallMask);
        if(hitColliders.Length != 0)
        {
            transform.parent.GetComponent<Animator>().CrossFade("Explode", 0f, 0, 1f);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.transform.gameObject.layer != 8)
        {
            transform.parent.GetComponent<Animator>().ResetTrigger("bugatti");
            transform.parent.GetComponent<Animator>().CrossFade("Explode", 0f, 0, 1f);
            if(other.transform.name == "Player")
            {
                transform.parent.GetComponent<Animator>().CrossFade("Explode", 0f, 0, 1f);
                other.transform.GetComponent<health>().hp -= 50;
            }
        }

    }
}
