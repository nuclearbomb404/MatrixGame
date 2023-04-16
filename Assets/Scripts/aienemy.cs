using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class aienemy : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject player, head;
    public LayerMask PlayerMask;
    public bool found,cooling;
    public Coroutine bruh;
    public Canvas canvas;
    public AudioClip hurt;
    // Start is called before the first frame update
    void Start()
    {
        rb  = gameObject.GetComponent<Rigidbody>();
        if(gameObject.layer == 9)
        {
            Rigidbody[] allRigidBodies = (Rigidbody[]) GameObject.FindObjectsOfType(typeof(Rigidbody));
            foreach(Rigidbody body in allRigidBodies)
            {
                if(body.gameObject.layer == 9)
                {
                    body.isKinematic = true;
                }
                    
            } 
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        speedcontrol();
        Detection();
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) < 3f)
        {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(gameObject.transform.position);
        }
    }
    void speedcontrol()
    {
        Vector3 flatvel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatvel.magnitude > 50)
        {
            Vector3 limitedVel = flatvel.normalized * 150;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
    void Detection()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 45, PlayerMask);
        foreach (var hitCollider in hitColliders)
        {
            Collider[] attackColliders = Physics.OverlapSphere(transform.position, 3, PlayerMask);
            Collider[] attackColliders2 = Physics.OverlapSphere(transform.position, 1, PlayerMask);
            if(attackColliders.Length != 0  && !cooling)
            {
                gameObject.transform.GetChild(1).GetComponent<Animator>().Play("EnemyAttack");
                if(Physics.BoxCast(gameObject.transform.GetChild(1).position, gameObject.transform.GetChild(1).GetComponent<Collider>().bounds.size, transform.forward,gameObject.transform.GetChild(1).transform.rotation,PlayerMask) && !cooling)
                {
                    player.GetComponent<AudioSource>().PlayOneShot(hurt);
                    player.GetComponent<health>().hitrecently = true;
                    player.GetComponent<health>().StartCoroutine("regen");
                    StartCoroutine("Cooldown");
                    player.GetComponent<health>().hp -= 25;
                    player.transform.GetChild(0).GetComponent<Animator>().Play("HitCamera");
                    player.GetComponent<ParticleSystem>().Play();
                }
            }
            gameObject.GetComponent<NavMeshAgent>().SetDestination(hitColliders[0].transform.position);
            gameObject.transform.LookAt(new Vector3(hitColliders[0].transform.position.x,transform.position.y,hitColliders[0].transform.position.z));
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            
        }

    }
    IEnumerator Cooldown()
    {
        cooling = true;
        yield return new WaitForSeconds(01.25f);
        cooling = false;
    }
}
