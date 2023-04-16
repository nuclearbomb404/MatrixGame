using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 500 ;
    public bool grounded = false;
    public LayerMask mask;
    public Transform sphere;
    float horizontalinput,verticalinput;
    Vector3 moveDir;
    public Transform orientation;
    public bool cooling;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        dodge();
        speedcontrol();
        horizontalinput = Input.GetAxisRaw("Horizontal");
        verticalinput = Input.GetAxisRaw("Vertical");
        void isGrounded()
        {
            if(Physics.Raycast(transform.position, Vector3.down, GetComponent<Collider>().bounds.extents.y + 0.1f, mask))
            {
                grounded = true;
            }
            else
            {
                grounded = false;
            }
        }
        isGrounded();

        if(Input.GetKeyDown(KeyCode.Space) && grounded )
        {
            rb.AddForce(0,15000f ,0);
        }
    }
    void FixedUpdate()
    {     
        walk();
    }
    void walk()
    {
        moveDir = orientation.forward * verticalinput + orientation.right * horizontalinput;
        rb.AddForce(moveDir.normalized * speed * 10, ForceMode.Force);
    }
    void speedcontrol()
    {
        Vector3 flatvel = new Vector3( rb.velocity.x, 0f, rb.velocity.z);
        if(flatvel.magnitude > 50)
        {
            Vector3 limitedVel = flatvel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);

        }
    }
    void dodge()
    {
        if(Input.GetKeyDown("e") && !cooling)
        {
            rb.AddForce(-transform.forward * 25000);
            StartCoroutine("Cooldown");
        }
    }
    IEnumerator Cooldown()
    {
        cooling = true;
        yield return new WaitForSeconds(1.75f);
        cooling = false;
    }
}
