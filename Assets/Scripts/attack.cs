using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    public GameObject sword;
    public bool strongatt;
    public Coroutine bruh;
    public AudioClip clip,clip2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            sword.GetComponent<Animator>().Play("Sword");
        }
        else if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sword.GetComponent<Animator>().Play("Sword2");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player")
        {
            if(sword.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Sword"))
            {
                if(other.GetComponent<health>() != null && other.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>() != null)
                {         
                    other.GetComponent<Rigidbody>().AddForce(-other.transform.forward * 10000);
                    other.GetComponent<health>().hp -= 25;
                    other.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                }
            }
            else if(sword.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Sword2"))
            {
                if(other.GetComponent<health>() != null)
                {
                    other.GetComponent<Rigidbody>().AddForce(-other.transform.forward * 13500);
                    other.GetComponent<health>().hp -= 80;
                    other.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
                }
            }
        }

    }

}
