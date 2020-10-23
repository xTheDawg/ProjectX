using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cameraMover : MonoBehaviour
{
    public Transform cameraTransform;
    
    private float yaw = 0;
    private float rotationSpeed = 2.5f;
    public float speed = 15f;
    private float cameraSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform.rotation = Quaternion.Euler(30, 0, 0);
        cameraTransform.position = new Vector3(0, 10, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        yaw += rotationSpeed * Input.GetAxis("Mouse X");
        cameraTransform.eulerAngles = new Vector3(0, yaw, 0);
        cameraSpeed = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.W))
        {
            cameraTransform.transform.position += Time.deltaTime * speed * new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            cameraTransform.transform.position = Vector3.left * speed * Time.deltaTime;
        }
    }
}
