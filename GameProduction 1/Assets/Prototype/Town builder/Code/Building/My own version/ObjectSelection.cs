using UnityEngine;

public class ObjectSelection : MonoBehaviour
{
    // What do i want this script to do?

    // Click onto objects. This will open a edit menu similar
    // rough concept seen on the mechanical design on the figma
    
    // Send raycast from camera
    // Does this match the layermask?
    // Highlight object mouse is hovering over
    // Does player click on the object?
    // If yes go into editing
    // 

    [Header("Properties")]
    public LayerMask SelectableObjects;
    
    Camera Cam;
    Renderer Rend;


    void Start(){
        Cam = Camera.main;

        Rend = GetComponent<Renderer>();
    }

    RaycastHit hit;
    void Update(){
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Cam.nearClipPlane;

        Ray ray = Cam.ScreenPointToRay(mousePos);

        if(Physics.Raycast(ray, out hit, 100, SelectableObjects)){
            Debug.Log(hit.transform.name);

            //IsHovering();
        }
        else{
            //NotHovering();
        } 
    }

    void IsHovering(){
        // This will just show if the player is currently 
        // hovering a object with the layer mask

        hit.transform.GetComponent<Renderer>().material.color = Color.red;
    }

    void NotHovering(){
        hit.transform.GetComponent<Renderer>().material.color = Color.white;
    } 

}
