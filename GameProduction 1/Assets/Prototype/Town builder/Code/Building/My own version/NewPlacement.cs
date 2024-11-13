using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

    /// <summary>
    /// Snap a mouse cursor to the grid (points)
    /// Once pressed on UI buttons a prefab is spawned in
    /// and will follow the mouse. 
    /// 
    /// Each object will have a 2 stages, editing and placed.
    /// This script will change that variable on the object
    /// whenever the player is placing to buy or to edit the
    /// building.
    /// </summary>

public class NewPlacement : MonoBehaviour
{
    [Header("Visuals")]
    public GameObject mouseIndicator;

    [Header("Selection and placement")]
    public ObjectsDataSO dataBase;
    public int SelectedID = -1;
    public GameObject EditingVisual;
    Vector3 mousePos;
    Vector3 lastPosition;
    Camera Cam;
    public LayerMask placementLayerMask;

    void Start(){
        StopPlacing();

        Cam = Camera.main;
    }

    void Update(){
        
    }

    public void StartPlacing(int ID){
        // Calling this function resets the current selected ID to nothing
        // This is needed to allow players to use their current selection.
        StopPlacing();

        SelectedID = dataBase.objectDataBases.FindIndex(data => data.ID == ID);

        if(SelectedID < 0){
            Debug.LogError($"No ID found {ID}");
            return;
        }

        // COPY ALL OF THE WIERD INPUT MANAGER FOR THIS AS YOU CANT USE THE CODE WITHOUT SIMILAR
        // MECHANICS

        /* GameObject newObject = Instantiate(dataBase.objectDataBases[SelectedID].Prefab);
        newObject.transform.position = MouseInWorld(); */

        //EditingVisual.SetActive(true);
        Debug.Log(MouseInWorld());

        SpawningANDPlacing();
    }

    void SpawningANDPlacing(){
        GameObject newObject = Instantiate(dataBase.objectDataBases[SelectedID].Prefab);
    }

    public void StopPlacing(){
        SelectedID = -1;
        EditingVisual.SetActive(false);
    }

    public Vector3 MouseInWorld(){
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
