using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class healthbar : MonoBehaviour
{
    public Slider slider;
    public GameObject player;
    public TMP_Text hptext;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    public void Update()
    {
        if(player != null)
        {
            slider.value = player.GetComponent<health>().hp;
            hptext.text = player.GetComponent<health>().hp.ToString("F0") + "/100";
        }
        else   
            slider.gameObject.SetActive(false);
    }
}
