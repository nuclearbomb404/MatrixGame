using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autodestruct : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name != "GunHit")
        {
            StartCoroutine("destruction");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator destruction()
    {
        yield return new WaitForSecondsRealtime(02);
        Destroy(gameObject);
    }
}
