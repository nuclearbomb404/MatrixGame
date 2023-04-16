using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moneycollision : MonoBehaviour
{
    public ParticleSystem explosion;
    // Start is called before the first frame update
    void Start()
    {
        explosion = gameObject.transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        ParticleSystem explosioninstance = Instantiate(explosion,gameObject.transform.position, gameObject.transform.rotation);
        explosioninstance.Play();
        Destroy(gameObject);
        if(other.transform.name == "Player")
        {
            other.transform.GetComponent<health>().hp -= 45;
        }
    }
}
