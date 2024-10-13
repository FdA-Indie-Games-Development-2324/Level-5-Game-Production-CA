using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float moveSpeed;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += transform.right * -moveSpeed * Time.deltaTime;

            Debug.Log("somethign happen?");
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += -transform.right * -moveSpeed * Time.deltaTime;
        }
    }
}
