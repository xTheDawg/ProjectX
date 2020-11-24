using UnityEngine;

// Deprecated
public class DeprecatedMoveToCursor : MonoBehaviour
{
    public float walkSpeed = 3f;
    public Vector3 targetPosition;
    public Vector3 lookAtTarget;
    public Quaternion playerRot;
    private float rotSpeed = 5f;
    private bool moving = false;

    Animator animator;
    CapsuleCollider capsuleCollider;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
