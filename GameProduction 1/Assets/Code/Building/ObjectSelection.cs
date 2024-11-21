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
    GameObject CurrentlyHit;

    void Update(){
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Cam.nearClipPlane;

        Ray ray = Cam.ScreenPointToRay(mousePos);

        if(Physics.Raycast(ray, out hit, 100, SelectableObjects)){
            //Debug.Log(hit.transform.name);

            CurrentlyHit = hit.transform.gameObject;

            IsHovering();

            Debug.Log(CurrentlyHit.transform.GetComponentInChildren<Renderer>().material.GetInt("_IsBeingHovered"));
            
            if(Input.GetMouseButtonDown(0) && !IsEditing){
                Editing();
            }
        }
        else{
            NotHovering();
        } 
    }

    // -------------------- HOVERING --------------------

    void IsHovering(){
        // This will just show if the player is currently 
        // hovering a object with the layer mask

        

        CurrentlyHit.transform.GetComponentInChildren<Renderer>().material.SetInt("_IsBeingHovered", 1);
        Debug.Log(CurrentlyHit.name);

    }

    void NotHovering(){
        //CurrentlyHit.transform.GetComponent<Renderer>().material.SetInt("_IsBeingHovered", 0);
    } 

    // -------------------- EDITING --------------------

    [Header("Editing")]
    public bool IsEditing;
    public GameObject CurrentEditGO;

    void Editing(){
        // Check are we already editing?
        // IF no. Activate a edit panel around the selected object.

        if(!IsEditing){
            // Set IsEditing to true so that players cant go and click on another GO
            IsEditing = true;
            
            // Need to set the object shader to be the consistent colour to show editing
            // until the players leaves the editing

            CurrentEditGO = CurrentlyHit;
            
            // Place or well snap the editing UI to here
            Debug.Log("You are now editing " + CurrentlyHit.transform.name);
        }
    }

}
