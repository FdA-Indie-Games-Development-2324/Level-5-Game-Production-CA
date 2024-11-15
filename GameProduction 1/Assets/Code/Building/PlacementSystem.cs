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

public class PlacementSystem : MonoBehaviour
{
    [Header("Visuals")]
    public GameObject mouseIndicator;

    [Header("Selection and placement")]
    public ObjectsDataSO dataBase;
    public BuildingManager buildingManager;
    public InputManager inputManager;
    public GridSystem newGrid;
    public int SelectedID = -1;
    public GameObject EditingVisual;
    Vector3 mousePos;
    Vector3 gridPos;
    Vector3 lastPosition;
    Camera Cam;
    public LayerMask placementLayerMask;

    void Start(){
        StopPlacing();
        minDist = 1;

        Cam = Camera.main;
    }


    public void StartPlacing(int ID){
        // Calling this function resets the current selected ID to nothing
        // This is needed to allow players to use their current selection.
        StopPlacing();

        SelectedID = dataBase.objectDataBases.FindIndex(data => data.ID == ID);

        Debug.Log(SelectedID);

        if(SelectedID < 0){
            Debug.LogError($"No ID found {ID}");
            return;
        }

        // COPY ALL OF THE WIERD INPUT MANAGER FOR THIS AS YOU CANT USE THE CODE WITHOUT SIMILAR
        // MECHANICS

        Cursor.visible = false;
        EditingVisual.SetActive(true);
        mouseIndicator.SetActive(true);

        inputManager.OnClicked += SpawningANDPlacing;
        inputManager.OnExit += StopPlacing;
    }

    void SpawningANDPlacing(){

        if(inputManager.isPointerOverUI()){
            return;
        } 

        mousePos = inputManager.GetSelectedMapPos();

        GameObject newObject = Instantiate(dataBase.objectDataBases[SelectedID].Prefab);
        newObject.transform.position = gridPos;

        Debug.Log(dataBase.objectDataBases[SelectedID].Type);

        if(dataBase.objectDataBases[SelectedID].Type == "House"){
            buildingManager.PlacedBuildings.Add(newObject);
            Debug.Log("is this working?");
        }

        if(dataBase.objectDataBases[SelectedID].Type == "Shop"){
            buildingManager.PlacedShops.Add(newObject);
        } 

        StopPlacing();
    }

    public void StopPlacing(){
        SelectedID = -1;
        EditingVisual.SetActive(false);
        mouseIndicator.SetActive(false);
        
        Cursor.visible = true;
    }

    float dist;
    float minDist;

    void Update(){
        if(SelectedID < 0){
            return;
        }

        Vector3 mousePos = inputManager.GetSelectedMapPos();
        
        for (int i = 0; i < newGrid.GridData.Count; i++)
        {
            // LOOP THROUGH ALL OF THE GOS AND CHECK WHAT IS CLOSEST TO THE MOUSE

            dist = Vector3.Distance(inputManager.GetSelectedMapPos(), newGrid.GridData[i].gameObject.transform.position);

            if(dist <= minDist){
                gridPos = newGrid.GridData[i].gameObject.transform.position;
                //Debug.Log(gridPos);
            }
        }
        
        mouseIndicator.transform.position = gridPos;

        Vector3 RayPoint = new Vector3(inputManager.hit.point.x, 0, inputManager.hit.point.z);
        
        //Debug.Log(inputManager.mousePos);
        EditingVisual.GetComponent<Renderer>().material.SetVector("_MouseCur", RayPoint);

    }
}
