using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraTransform;

    private static float angle = 30f;
    private float yaw = 90f;
    private float rotationSpeed = 1.5f;
    private float sinAngle = Mathf.Sin(angle * (Mathf.PI) / 180);
    private float cosAngle = Mathf.Cos(angle * (Mathf.PI) / 180);
    public float speed = 15f;
    RaycastHit hit;
    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform.position = new Vector3(-20, 10, 0);
        cameraTransform.eulerAngles = new Vector3(angle, yaw,0);
        Cursor.visible = true;
        mainCam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (Input.GetKey(KeyCode.E) && mainCam.enabled)
        {
            yaw += rotationSpeed;// * Input.GetAxis("Mouse X");
            cameraTransform.eulerAngles = new Vector3(angle, yaw, 0);
        }
        
        if (Input.GetKey(KeyCode.Q) && mainCam.enabled)
        {
            yaw -= rotationSpeed;// * Input.GetAxis("Mouse X");
            cameraTransform.eulerAngles = new Vector3(angle, yaw, 0);
        }

        if (Input.GetKey(KeyCode.W) && mainCam.enabled)
        {
            cameraTransform.transform.Translate(Vector3.forward * speed * Time.deltaTime * (1 + sinAngle) * 0.7f);
            cameraTransform.transform.Translate(Vector3.up * speed * Time.deltaTime * cosAngle * 0.7f);
        }
        
        if (Input.GetKey(KeyCode.A) && mainCam.enabled)
        {
            cameraTransform.transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.S) && mainCam.enabled)
        {
            cameraTransform.transform.Translate(Vector3.back * speed * Time.deltaTime * (1 + sinAngle) * 0.7f);
            cameraTransform.transform.Translate(Vector3.down * speed * Time.deltaTime * cosAngle * 0.7f);
        }
        
        if (Input.GetKey(KeyCode.D) && mainCam.enabled)
        {
            cameraTransform.transform.Translate(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.F) && mainCam.enabled)
        {
            if (cameraTransform.transform.position.y >= 5)
            {
                cameraTransform.transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
        }
        
        if (Input.GetKey(KeyCode.R) && mainCam.enabled)
        {
            if (cameraTransform.transform.position.y <= 30)
            {
                cameraTransform.transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
        }
        
        if ( Input.GetMouseButtonDown (0)){
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            if ( Physics.Raycast (ray,out hit,100.0f)) {
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                if (hit.transform.name.Equals("PT_Medieval_Male_Peasant_01_a(Clone)"))
                {
                    mainCam.enabled = false;
                    hit.transform.gameObject.GetComponentInChildren<Camera>().enabled = true;
                }
            }
        }

        if (Input.GetKey(KeyCode.X) && mainCam.enabled == false)
        {
            hit.transform.gameObject.GetComponentInChildren<Camera>().enabled = false;
            mainCam.enabled = true;
        }

        if (mainCam.enabled == false)
        {
            cameraTransform.transform.position = hit.transform.gameObject.transform.position + new Vector3(0,10,0);
        }
    }
}
