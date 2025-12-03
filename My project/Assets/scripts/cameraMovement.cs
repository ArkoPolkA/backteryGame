using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float minDistance = 1.0f;
    public float maxDistance = 5.0f;

    public float xSpeed = 120.0f;
   

 

    public float collisionOffset = 0.2f;
    public LayerMask collisionLayers = ~0;

    private float x = 0.0f;
 

    void Start()
    {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
      

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (target == null) return;

        x += Input.GetAxis("Mouse X") * xSpeed * Time.deltaTime;
       
      

        Quaternion rotation = Quaternion.Euler(90f, x, 0f);
        Vector3 forward = rotation * Vector3.forward;

        float correctedDistance = distance;

        if (Physics.Raycast(target.position, -forward, out RaycastHit hit, distance, collisionLayers))
        {
            correctedDistance = Mathf.Clamp(hit.distance - collisionOffset, minDistance, maxDistance);
        }

        Vector3 finalPosition = target.position - forward * correctedDistance;

        
        target.rotation = Quaternion.Euler(0f, x, 0f);

        transform.rotation = rotation;
        transform.position = finalPosition;
    }
}
