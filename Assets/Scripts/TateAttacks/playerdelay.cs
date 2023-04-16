using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerdelay : MonoBehaviour
{
    public Transform zaza;
    public bool cooling;
    public int damage = 55;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void StartDelay()
    {
        StartCoroutine("PlayerDelay");
    }
    public IEnumerator PlayerDelay()
    {
        cooling = true;
        yield return new WaitForSeconds(2);
        cooling = false;
    }
    void OnParticleCollision(GameObject other)
    {
        if(other.name == "Player" && !cooling)
        {
            if(other.transform.GetComponent<health>() != null)
            {
                StartCoroutine("PlayerDelay");
                other.transform.GetComponent<health>().hp -= damage;
            }
        }
    }
}
