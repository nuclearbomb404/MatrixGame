using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class shooting : MonoBehaviour
{
    public GameObject maincamera;
    public LayerMask enemymask, notenemymask;
    public GameObject gun, postprocess, dust;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1) && !maincamera.transform.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Gun")&& !maincamera.transform.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Gun2"))
        {
            StartCoroutine("AnimDelay");
        }

    }
    IEnumerator AnimDelay()
    {
        maincamera.GetComponent<Animator>().Play("Gun");
        yield return new WaitForSecondsRealtime(0.3f);
        gun.GetComponent<ParticleSystem>().Play();
        gameObject.GetComponent<AudioSource>().PlayOneShot(clip);
        yield return new WaitForSecondsRealtime(0.05f);
        shootafteranim();
        yield return new WaitForSecondsRealtime(0.02f);
        maincamera.GetComponent<Animator>().Play("Gun2");

    }
    void shootafteranim()
    {
        RaycastHit hit;
        if(Physics.Raycast(maincamera.transform.position,maincamera.transform.forward,out hit,100f, enemymask))
        {
            hit.collider.gameObject.GetComponent<health>().hp -= 75;
            hit.collider.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        }
        if(Physics.Raycast(maincamera.transform.position,maincamera.transform.forward,out hit,100f, notenemymask))
        {
            GameObject dustinstance = Instantiate(dust, hit.point, transform.rotation);
        }
    }
}
