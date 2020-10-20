using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PeasantMover : MonoBehaviour
{
    private float speed;
    public float walkSpeed = 0.03f;
    public float rotationSpeed = 2.5f;
    
    Rigidbody rigidbody;
    Animator animator;
    CapsuleCollider capsuleCollider;

    public Transform cameraTransform;

    private float yaw = 0;
    private float pitch = 0;

    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.GetComponent<Animator>();
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float z = Input.GetAxis("Vertical") * speed;
        float y = Input.GetAxis("Horizontal") * rotationSpeed;
        transform.Translate(0, 0, z);
        transform.Rotate(0, y, 0);

        yaw += rotationSpeed * Input.GetAxis("Mouse X");
        pitch -= rotationSpeed * Input.GetAxis("Mouse Y");
        transform.eulerAngles = new Vector3(0, yaw, 0);
        cameraTransform.eulerAngles = new Vector3(pitch, yaw, 0);

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        speed = walkSpeed;
    }
}
