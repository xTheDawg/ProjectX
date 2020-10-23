using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PeasantMover : MonoBehaviour
{
    private float speed;
    public float walkSpeed = 5f;
    public float rotationSpeed = 2.5f;
    public Vector3 targetPosition;
    public Vector3 lookAtTarget;
    public Quaternion playerRot;
    private float rotSpeed = 5f;
    private bool moving = false;
    
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
        /*float z = Input.GetAxis("Vertical") * speed;
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

        speed = walkSpeed;*/

        if (Input.GetMouseButton(0))
        {
            SetTargetPosition();
        }

        if (moving)
        {
            Move();
        }
        
    }
    
    void SetTargetPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 500))
        {
            targetPosition = hit.point;
            //this.transform.LookAt(targetPosition);
            lookAtTarget = new Vector3(targetPosition.x - transform.position.x,
                transform.position.y,
                targetPosition.z - transform.position.z);
            playerRot = Quaternion.LookRotation(lookAtTarget);
            moving = true;
            animator.SetBool("isWalking", true);
        }
    }

    void Move()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation,
            playerRot,
            rotSpeed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position,
            targetPosition,
            walkSpeed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            moving = false;
            animator.SetBool("isWalking", false);
        }
    }
}
