using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PeasantMover : MonoBehaviour
{
    public Rigidbody rb;
    public Animator anim;

    public float sidewaysForce = 500f;

    public float speed = 10.0f;

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKey("d"))
        {
            anim.SetBool("isTurningRight",true);   
        }else{
            anim.SetBool("isTurningRight",false);
        }
        
        if (Input.GetKey("a"))
        {
            anim.SetBool("isTurningLeft",true);   
        }else{
            anim.SetBool("isTurningLeft",false);
        }
        
        if (Input.GetKey("w"))
        {
            anim.SetBool("isWalking",true);   
        }else{
            anim.SetBool("isWalking",false);
        }
        
        if (Input.GetKey("s"))
        {
            anim.SetBool("isWalkingBack",true);   
        }else{
            anim.SetBool("isWalkingBack",false);
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
