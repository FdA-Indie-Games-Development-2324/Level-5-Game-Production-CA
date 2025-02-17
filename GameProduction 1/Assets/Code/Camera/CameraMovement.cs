using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Camera ZoomCam;
    public float ScrollSpeed;
    public float speed = 5f;
    public float ShiftSpeed = 7f;

    void Start(){
        ZoomCam = Camera.main;
    }

    void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));


        if(Input.GetKey(KeyCode.LeftShift)){
            transform.position += moveDirection.normalized * ShiftSpeed * Time.deltaTime;
        }
        else{
            transform.position += moveDirection.normalized * speed * Time.deltaTime;
        }
        
        ZoomCam.orthographicSize = Mathf.Clamp(ZoomCam.orthographicSize, 5, 18);

        if(ZoomCam.orthographic){
            ZoomCam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * ScrollSpeed;
        }


    }
}
