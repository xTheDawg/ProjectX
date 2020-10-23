using UnityEngine;

public class cameraMover : MonoBehaviour
{
    public Transform cameraTransform;

    private static float angle = 30f;
    private float yaw = 90f;
    private float rotationSpeed = 3f;
    private float sinAngle = Mathf.Sin(angle * (Mathf.PI) / 180);
    private float cosAngle = Mathf.Cos(angle * (Mathf.PI) / 180);
    public float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform.position = new Vector3(-20, 10, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        yaw += rotationSpeed * Input.GetAxis("Mouse X");
        cameraTransform.eulerAngles = new Vector3(angle, yaw, 0);

        if (Input.GetKey(KeyCode.W))
        {
            cameraTransform.transform.Translate(Vector3.forward * speed * Time.deltaTime * (1 + sinAngle) * 0.7f);
            cameraTransform.transform.Translate(Vector3.up * speed * Time.deltaTime * cosAngle * 0.7f);
        }
        
        if (Input.GetKey(KeyCode.A))
        {
            cameraTransform.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.S))
        {
            cameraTransform.transform.Translate(Vector3.back * speed * Time.deltaTime * (1 + sinAngle) * 0.7f);
            cameraTransform.transform.Translate(Vector3.down * speed * Time.deltaTime * cosAngle * 0.7f);
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            cameraTransform.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            if (cameraTransform.transform.position.y >= 5)
            {
                cameraTransform.transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
        
        if (Input.GetKey(KeyCode.E))
        {
            if (cameraTransform.transform.position.y <= 30)
            {
                cameraTransform.transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
    }
}
