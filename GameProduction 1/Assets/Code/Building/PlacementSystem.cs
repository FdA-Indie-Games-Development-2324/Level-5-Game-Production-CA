using System;
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
    public Material PreviewMaterial;

    [Header("Selection and placement")]
    public BuildingMenu HotbarScript;
    public ObjectsDataSO dataBase;
    public BuildingManager buildingManager;
    public InputManager inputManager;
    public GridSystem newGrid;
    public int SelectedID = -1;
    public GameObject EditingVisual;
    Vector3 mousePos;
    Vector3 gridPos;
    Vector3 lastPosition;
    GameObject TempPreview;
    bool IsPlacing;
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

        HotbarScript.CanSwitch = false;
        HotbarScript.CurrentActivePanel.GetComponent<SimpleAnimations>().PanelMoving(false);

        SelectedID = dataBase.objectDataBases.FindIndex(data => data.ID == ID);

        Debug.Log(SelectedID);

        if(SelectedID < 0){
            Debug.LogError($"No ID found {ID}");
            return;
        }

        // This is my own written code in this section as I really did not want to follow the tut

        // Need to make it so that there is a preview version of the prefab. Everything to do this
        // is already provided in some form in this code already from prefab to display to mousePos
        
        // Also note for checking collisions. Not doing that. The prefabs once spawned will delete
        // Everything within its space.

        // As by the point of this function being called the player is moving the mouse around to
        // place down the building somewhere soooo this is the prefect place to quickly spawn a temp
        // version of the prefab and switch out all of its materials to look like a blueprint.

        // I will be calling a seperate function to keep this section clean;

        PrefabPlacementPreview(SelectedID);

        // End of my version


        // COPY ALL OF THE WIERD INPUT MANAGER FOR THIS AS YOU CANT USE THE CODE WITHOUT SIMILAR
        // MECHANICS - idk what this guy is talking about tbh

        Cursor.visible = false;
        EditingVisual.SetActive(true);
        mouseIndicator.SetActive(true);

        inputManager.OnClicked += SpawningANDPlacing;
        inputManager.OnExit += StopPlacing;
    }

    private void PrefabPlacementPreview(int ID)
    {
        //Debug.Log("Spawned the preview");

        // First would be to change the scale of the mouse indicator
        // The scale of the mouse indicator will be determind by the set size on the Scriptable object
        mouseIndicator.GetComponentInChildren<Transform>().transform.localScale = new Vector3(
                                                                                            dataBase.objectDataBases[ID].GridSize.x, 
                                                                                            0.4f, 
                                                                                            dataBase.objectDataBases[ID].GridSize.y);

        mouseIndicator.GetComponentInChildren<Renderer>().material.SetFloat("_GridSize", dataBase.objectDataBases[ID].GridSize.x);
                                                                                            
        // Now time to spawn the asset
        // As a little cheese I will add this prefab to be attached to the mouse indicator. I dont need to move it then
        TempPreview = Instantiate(dataBase.objectDataBases[ID].Prefab);

        // Allow the preview to move around via Update()
        IsPlacing = true;

        // Then also change all of the materials to the preview material
        // This is the same as the tutorial ish
        Renderer[] renderers = TempPreview.transform.GetComponentsInChildren<Renderer>();
        foreach (Renderer item in renderers)
        {
            Material[] materials = item.materials;
            for (int i = 0; i < materials.Length; i++)
            {
                materials[i] = PreviewMaterial;
            }
            item.materials = materials;
        }
    }

    void SpawningANDPlacing(){

        if(inputManager.isPointerOverUI()){
            return;
        } 

        mousePos = inputManager.GetSelectedMapPos();

        GameObject newObject = Instantiate(dataBase.objectDataBases[SelectedID].Prefab);
        newObject.transform.position = gridPos;

        //Debug.Log(dataBase.objectDataBases[SelectedID].Type);

        if(dataBase.objectDataBases[SelectedID].Type == "House"){
            buildingManager.PlacedBuildings.Add(newObject);
            //Debug.Log("is this working?");
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

        HotbarScript.CanSwitch = true;
        if(HotbarScript.CurrentActivePanel.GetComponent<SimpleAnimations>() != null){
            HotbarScript.CurrentActivePanel.GetComponent<SimpleAnimations>().PanelMoving(true);
        }

        // OWN CODE

        // Considering that the player has just clicked to place the prefab it would probably be 
        // best to destroy the preview version. 
        Destroy(TempPreview);

        // END OF MY CODE
        
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

        // Start of own code

        if(IsPlacing){
            TempPreview.transform.position = gridPos;
        }

        // End of own code
        
        mouseIndicator.transform.position = gridPos;

        Vector3 RayPoint = new Vector3(inputManager.hit.point.x, 0, inputManager.hit.point.z);
        
        Debug.Log(inputManager.mousePos);
        //EditingVisual.GetComponent<Renderer>().material.SetVector("_MouseCur", RayPoint);

    }
}