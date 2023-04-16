using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousecam : MonoBehaviour
{
    public float sensitivity = 10000f;
    public Transform player;
    float xrotation = 0f;
    public bool CursorLock = true;
    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity* Time.fixedDeltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity* Time.fixedDeltaTime;
        xrotation -= mouseY;
        xrotation = Mathf.Clamp(xrotation, -91f, 89f);
        transform.localRotation = Quaternion.Euler(xrotation, 0f, 0f);
        player.Rotate(Vector3.up * mouseX);
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            CursorLock = !CursorLock;
        }
        if(!CursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 01;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }
    }
}
