using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tatehealthbar : MonoBehaviour
{
    public Slider slider;
    public GameObject tate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        if(tate != null)
            slider.value = tate.GetComponent<health>().hp;
        else   
            slider.gameObject.SetActive(false);
    }
}
