using TMPro;
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
    //public LayerMask SelectableObjects;
    Camera Cam;
    Renderer Rend;
    RaycastHit hit;
    public bool EditMode;
    public GameObject LastHighlighted;
    public GameObject CurrentlyHighlighted;

    [Header("Script references")]
    public PlayerStatistics playerStatistics;
    public BuildingMenu HotbarScript;
    public InputManager inputManager;

    void Start(){
        Cam = Camera.main;

        Rend = GetComponent<Renderer>();
    }


    void Update(){
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Cam.nearClipPlane;

        Ray ray = Cam.ScreenPointToRay(mousePos);


        if(EditMode && Physics.Raycast(ray, out hit, 100)){
            //Debug.Log(hit.transform.name);
            CurrentlyHighlighted = hit.transform.gameObject;

            // HIGHLIGHTING
            if(CurrentlyHighlighted.layer == LayerMask.NameToLayer("EditableGO") && !IfHigh && !IsEditing){
                IsHovering();
                LastHighlighted = CurrentlyHighlighted;
                //Debug.Log("Are we getting here?");
            }

            // Select
            if(Input.GetMouseButtonDown(0) && CurrentlyHighlighted.layer == LayerMask.NameToLayer("EditableGO") && IfHigh && !IsEditing){
                CurrentEditGO = CurrentlyHighlighted;
                HotbarScript.CanSwitch = false;
                Editing();
                //Debug.Log("Are we getting here?");

                // Audio
                MainButtonAudioSource.clip = onClickToEdit;
                MainButtonAudioSource.Play();
            }

            // Not hovering anymore
            if(CurrentlyHighlighted != LastHighlighted && LastHighlighted != null && !IsEditing){
                NotHovering();
            }
        }
    }

    // -------------------- HOVERING --------------------

    public Material[] HoveringMat;
    public bool IfHigh;

    public void IsHovering(){
        // This will just show if the player is currently 
        // hovering a object with the layer mask

        IfHigh = true;

        HoveringMat = CurrentlyHighlighted.transform.GetComponent<Renderer>().materials;
        
        foreach (var item in HoveringMat)
        {
            item.SetInt("_IsBeingHovered", 1);
        }

    }

    public void NotHovering(){
        HoveringMat = LastHighlighted.transform.GetComponent<Renderer>().materials;
        
        IfHigh = false;

        foreach (var item in HoveringMat)
        {
            item.SetInt("_IsBeingHovered", 0);
        }
    } 

    // -------------------- EDITING --------------------

    [Header("Editing")]
    public bool IsEditing;
    public GameObject CurrentEditGO;

    [Space(10)]
    public GameObject MenuParent;
    public TMP_Text ObjectName;

    [Space(10)]
    public AudioSource MainButtonAudioSource;
    public AudioClip onClickToEdit;
    public AudioClip onClickToConfirm;

    void Editing(){
        // Check are we already editing?
        // IF no. Activate a edit panel around the selected object.

        if(!IsEditing){
            // Set IsEditing to true so that players cant go and click on another GO
            IsEditing = true;
            
            GetObjectData();
            MenuParent.SetActive(true);

            // Need to set the object shader to be the consistent colour to show editing
            // until the players leaves the editing
            IsHovering();

        }
    }

    public void ConfirmEdit(){
        // This will close the edit mode and allow the player to select a new object

        CurrentEditGO = null;

        HotbarScript.CanSwitch = true;

        IsEditing = false;

        MenuParent.SetActive(false);

        NotHovering();

        // Audio
        MainButtonAudioSource.clip = onClickToConfirm;
        MainButtonAudioSource.Play();
    }

    void GetObjectData(){
        Debug.Log("Grabbed object data");
        if(CurrentEditGO.tag == "Tree"){
            //Debug.Log("This is a tree");
            ObjectName.text = "Tree";
        }

        if(CurrentEditGO.tag == "Bush"){
            //Debug.Log("This is a tree");
            ObjectName.text = "Bush";
        }

        if(CurrentEditGO.tag == "SmallHouse"){
            //Debug.Log("This is a tree");
            ObjectName.text = "Small house";
        }

        if(CurrentEditGO.tag == "LargeHouse"){
            //Debug.Log("This is a tree");
            ObjectName.text = "Large house";
        }

        if(CurrentEditGO.tag == "WoodMill"){
            //Debug.Log("This is a tree");
            ObjectName.text = "Wood mill";
        }
    }

    public void Upgrade(){
        
    }

    public void RemoveObj(){
        if(CurrentEditGO.tag == "Tree"){
            playerStatistics.Rescoure += 5;
            playerStatistics.RefreshResource();
        }

        if(CurrentEditGO.tag == "Bush"){
            playerStatistics.Rescoure += 1;
            playerStatistics.RefreshResource();
        }

        if(CurrentEditGO.tag == "SmallHouse"){
            playerStatistics.Rescoure += 20;
            playerStatistics.RefreshResource();
        }

        if(CurrentEditGO.tag == "LargeHouse"){
            playerStatistics.Rescoure += 30;
            playerStatistics.RefreshResource();
        }
        
        if(CurrentEditGO.tag == "BlackSmith"){
            playerStatistics.Rescoure += 50;
            playerStatistics.RefreshResource();
        }

        if(CurrentEditGO.tag == "WoodMill"){
            playerStatistics.Rescoure += 50;
            playerStatistics.RefreshResource();
        }
        ConfirmEdit();
    }
}