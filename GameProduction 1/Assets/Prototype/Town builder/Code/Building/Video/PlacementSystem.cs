using System;
using System.Collections.Generic;
using UnityEngine;

public class PlacementSystem : MonoBehaviour
{
    public GameObject mouseIndicator, cellIndicator;
    public InputManager inputManager;
    public Grid grid;

    [Header("Selection & placement")]
    public ObjectsDataSO database;
    public int SelectedID = -1;
    public GameObject gridVisual;

    private GridData floorData, anythingElseData;
    private Renderer previewRender;

    public List<GameObject> placedGameObjects = new();

    void Start(){
        StopPlacement();

        floorData = new();
        anythingElseData = new();
        previewRender = cellIndicator.GetComponentInChildren<Renderer>();
    }

    public void StartPlacement(int ID){
        StopPlacement();
        // Loops through the IDs stored within the database and sets the SelectedID to the database ID.
        SelectedID = database.objectDataBases.FindIndex(data => data.ID == ID);

        if(SelectedID < 0){
            Debug.LogError($"No ID found {ID}");
            return;
        }
        gridVisual.SetActive(true);
        cellIndicator.SetActive(true);
        inputManager.OnClicked += PlaceStructure;
        inputManager.OnExit += StopPlacement;
    }

    private void PlaceStructure()
    {
        if(inputManager.isPointerOverUI()){
            return;
        }
        Vector3 mousePos = inputManager.GetSelectedMapPos();
        Vector3Int gridPos = grid.WorldToCell(mousePos);

        bool placementValid = CheckPlacementValid(gridPos, SelectedID);
        if(placementValid == false){
            return;
        }

        GameObject newObject = Instantiate(database.objectDataBases[SelectedID].Prefab);
        newObject.transform.position = grid.CellToWorld(gridPos);

        placedGameObjects.Add(newObject);
        GridData selectedData = database.objectDataBases[SelectedID].ID == 0 ? floorData : anythingElseData;
        
        selectedData.AddObjectAt(gridPos, 
            database.objectDataBases[SelectedID].Size, 
            database.objectDataBases[SelectedID].ID, 
            placedGameObjects.Count - 1); 

    }

    private bool CheckPlacementValid(Vector3Int gridPos, int selectedID)
    {
        GridData selectedData = database.objectDataBases[SelectedID].ID == 0 ? floorData : anythingElseData;

        return selectedData.CanPlaceObjectAt(gridPos, database.objectDataBases[selectedID].Size);
    }

    private void StopPlacement()
    {
        SelectedID = -1;
        gridVisual.SetActive(false);
        cellIndicator.SetActive(false);
        inputManager.OnClicked -= PlaceStructure;
        inputManager.OnExit -= StopPlacement;
    }

    void Update(){

        if(SelectedID < 0)
            return;

        Vector3 mousePos = inputManager.GetSelectedMapPos();
        Vector3Int gridPos = grid.WorldToCell(mousePos);

        bool placementValid = CheckPlacementValid(gridPos, SelectedID);
        previewRender.material.color =  placementValid ? Color.white : Color.red ;

        mouseIndicator.transform.position = mousePos;
        cellIndicator.transform.position = grid.CellToWorld(gridPos);
    }
}
