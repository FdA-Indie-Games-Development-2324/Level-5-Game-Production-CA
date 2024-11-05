using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera ZoomCam;
    public float ScrollSpeed;
    public float speed = 5f;

    void Start(){
        ZoomCam = Camera.main;
    }

    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        transform.position += moveDirection * speed * Time.deltaTime;
        
        ZoomCam.orthographicSize = Mathf.Clamp(ZoomCam.orthographicSize, 5, 18);

        if(ZoomCam.orthographic){
            ZoomCam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        }

    }
}
