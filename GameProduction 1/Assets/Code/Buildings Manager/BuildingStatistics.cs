using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;

public class BuildingStatistics : MonoBehaviour
{
    [Header("Requirements")]
    public ObjectsDataSO dataBase;
    [Tooltip("What ID does this item come from in the obj database? This has to be the same index that is used for the buttons to spawn this very object!")]
    public int ID;

    public GameObject[] BuildingTiers;

    [Header("Basic stats")]
    public int BuildingLevel;
    private float XPGain;

    public float RequiredGold;
    public float RequiredResources;

    private float TimeToBuild;
    private float TimeToDestroy;

    [Header("If resource generator")]
    private float GenerationAmount;
    private float GenerationTime;

    [Header("Extras")]
    [Tooltip("Fill this in manually")]
    public float DestroyResourceAmount;

    // Extra hidden stuff
    GameObject CentrePoint;
    PlayerStatistics PlayerStaticsGO;
    bool ResourceGenerator;

    void Start(){
        SetValues();

        // Needed to see if this building will generate resources or not
        CheckType();


        // Find some things in the game scene
        CentrePoint = gameObject.transform.Find("CentrePoint").gameObject;
        PlayerStaticsGO = GameObject.Find("PlayerStats").GetComponent<PlayerStatistics>();
        
        // Delete everything around this object
        ClearSpace();

        // Since the building has just been placed it needs time to build
        if(Time.time > TimeToBuild){
            Debug.Log("Structure completed");

            PlayerStaticsGO.CurrentXPAmount += XPGain;
        }
    }

    void Update(){
        if(ResourceGenerator){
            // Generate resources here
        }
    }

    void ClearSpace(){
        // Need to destroy and objects that are under the editable layer

        // This will create a quick OverlapSphere at the location to check if the placement is valid
        Collider[] cols = Physics.OverlapSphere(CentrePoint.transform.position, dataBase.objectDataBases[ID].GridSize.x);

        foreach (Collider col in cols)
        {
            Debug.Log("Collided with " + col.transform.name);
            Destroy(col, 1);
        }
    }

    void CheckType(){
        if(dataBase.objectDataBases[ID].Type == "House"){

        }else{
            ResourceGenerator = true;
        }
    }

    void SetValues(){
        // Need to grab all of the data to fill out the empty variables

        BuildingLevel = dataBase.objectDataBases[ID].BuildingLevel;
        XPGain = dataBase.objectDataBases[ID].XPGain;
        RequiredGold = dataBase.objectDataBases[ID].RequiredGold;

        TimeToBuild = dataBase.objectDataBases[ID].TimeToBuild;
        TimeToDestroy = dataBase.objectDataBases[ID].TimeToDestroy;

        GenerationAmount = dataBase.objectDataBases[ID].GenerationAmount;
        GenerationTime = dataBase.objectDataBases[ID].GenerationTime;
    }

    void BuildingStage(){
        
    }
}