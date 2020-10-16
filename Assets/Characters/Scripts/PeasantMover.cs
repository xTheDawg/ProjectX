using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PeasantMover : MonoBehaviour
{
    public Rigidbody rb;

    public float sidewaysForce = 500f;

    public float speed = 10.0f;

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey("d"))
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        
        if (Input.GetKey("a"))
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        
        if (Input.GetKey("w"))
        {
            rb.AddForce(0,  0, sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
        }
        
        if (Input.GetKey("s"))
        {
            rb.AddForce(0,  0, -sidewaysForce * Time.deltaTime, ForceMode.VelocityChange);
        }
    }

    void Awake() {    
        rb.position = new Vector3(5.0f, 0.0f, 5.0f);
    }

    /*void Update() {
        float step =  speed * Time.deltaTime; // calculate distance to move

        rb.position = Vector3.MoveTowards(rb.position, new Vector3(100.0f, 0.0f, 100.0f), step);
        //rb.position = new Vector3(100.0f, 0.0f, 100.0f);
    
    }*/
}
