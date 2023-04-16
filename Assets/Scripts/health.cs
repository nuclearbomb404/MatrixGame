using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class health : MonoBehaviour
{
    public Rigidbody rb;
    public float hp = 100;
    public TextMeshProUGUI hptext;
    public GameObject player, postprocess, ragdoll;
    public int prevhp ;
    public bool regening = false;
    public bool hitrecently = false;
    public GameObject DeathUI;
    public bool secondphase;
    // Start is called before the first frame update
    void Update()
    {                
        if(Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
        if(hp < 250 && gameObject.name == "tate")
        {
            gameObject.GetComponent<Animator>().SetTrigger("secondphase");
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        if(!hitrecently && hp <100 && gameObject.name =="Player")
        {
            hp += 0.1f;
        }
        if(hp < 1 )
        {
            if(gameObject.name != "Player" && gameObject.name != "tate")
            {
                foreach(Transform child in gameObject.transform)
                {
                    if(child.gameObject.name != "character (1)" &&child.gameObject.name != "glasses")
                    {
                        child.gameObject.SetActive(false);
                    }
                    if(child.gameObject.name == "glasses")
                    {
                        child.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                    }

                }

                foreach (Behaviour childCompnent in gameObject.GetComponentsInChildren<Behaviour>())
                {
                    childCompnent.enabled = false;
                }

                if(gameObject.layer == 9)
                {
                    Rigidbody[] allRigidBodies = (Rigidbody[]) GameObject.FindObjectsOfType(typeof(Rigidbody));
                    foreach(Rigidbody body in allRigidBodies)
                    {
                        if(body.gameObject.layer == 9)
                        {
                            body.isKinematic = false;
                        }
                            
                    } 
                }
            }
            else if(gameObject.name == "Player")
            {
                DeathUI.gameObject.GetComponent<Animator>().SetTrigger("dead");
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
        if(hp > 51 && gameObject.name == "Player")
        {
            PostProcessVolume m_Volume;
            Vignette m_Vignette;
            m_Vignette = ScriptableObject.CreateInstance<Vignette>();
            m_Vignette.enabled.Override(true);
            m_Vignette.intensity.Override(1f);
            m_Vignette.intensity.value = 0.1f;
            m_Volume =  PostProcessManager.instance.QuickVolume(postprocess.layer, 100f, m_Vignette);
        }
        if(hp < 31 && gameObject.name == "Player")
        {
            PostProcessVolume m_Volume;
            Vignette m_Vignette;
            m_Vignette = ScriptableObject.CreateInstance<Vignette>();
            m_Vignette.enabled.Override(true);
            m_Vignette.intensity.Override(1f);
            m_Vignette.intensity.value = 1-(hp/25f);
            m_Vignette.color.value = Color.red;
            m_Volume =  PostProcessManager.instance.QuickVolume(postprocess.layer, 100f, m_Vignette);
        }
        

    }
    IEnumerator regen()
    {
        yield return new WaitForSeconds(4); 
        hitrecently = false;
    }
}
