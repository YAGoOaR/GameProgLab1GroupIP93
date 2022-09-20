using UnityEngine;

//A script that makes camera follow player
public class Follow : MonoBehaviour
{
    [SerializeField] float moveStep = 0.5f;
    Camera Cam;
    Transform camTransform;
    Rigidbody2D rb;

    void Awake()
    {
        GameObject cameraObject = Camera.main.gameObject;
        camTransform = cameraObject.transform;
        camTransform.position = new Vector3(transform.position.x, transform.position.y, camTransform.position.z);
        Cam = cameraObject.GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        float size = Mathf.Clamp(Cam.orthographicSize * (1 - Input.GetAxis("Mouse ScrollWheel")), 5, 10);
        Cam.orthographicSize = size;

        Vector2 delta = camTransform.position - transform.position;
        float distance = delta.magnitude;

        Vector3 move = delta.normalized * moveStep * (1 + 3 * distance) * Time.deltaTime;
        if (move.magnitude > distance) move = delta;
        camTransform.position += (Vector3)rb.velocity * Time.deltaTime * 0.5f - move;
    }

}
