using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    public Camera Cam;
    Vector3 lastPosition;
    public LayerMask placementLayerMask;

    public event Action OnClicked, OnExit;

    void Awake(){
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Confined;
    }

    void Update(){
        if(Input.GetMouseButtonDown(0)){
            OnClicked.Invoke();
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            OnExit.Invoke();
        }
    }

    public bool isPointerOverUI()
        => EventSystem.current.IsPointerOverGameObject();

    public Vector3 GetSelectedMapPos(){

        // gets the mouse poisition as a Vector3
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Cam.nearClipPlane;

        Ray ray = Cam.ScreenPointToRay(mousePos);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100, placementLayerMask)){
            lastPosition = hit.point;
        }

        return lastPosition;
    }
}
