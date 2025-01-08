using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoringMultipleVaribles : MonoBehaviour
{
    public List<StoredBuildings> PlacedBuildings = new List<StoredBuildings>();

    public Transform PlacedBuildingsParent;
    public ObjectsDataSO dataBase;

    void Update(){

        // Wood generation

        // Money generation

    }

    void UpdateWoodGeneration(){
        // If a building has been added and it has something to do with wood generation
        // Update the values here so that the update function can continue with the new
        // building accounted for. This will also be used for upgrading buildings.
    }

    void UpdateMoneyGeneration(){

    }

    void UpdateResisdentCount(){

    }

    public void PlaceBuilding(int index){

        // Spawning and adding to list.
        GameObject GOTest = Instantiate(dataBase.objectDataBases[index].Prefab, PlacedBuildingsParent);

        // This stops the first index from being -1
        if(PlacedBuildings.Count == 0)
        {
            PlacedBuildings.Add(new StoredBuildings(0, dataBase.objectDataBases[index].Type, 
                                                        dataBase.objectDataBases[index].GenerationAmount,
                                                        dataBase.objectDataBases[index].GenerationTime));
        }
        else
        {
            // Adds the newly placed building to the list using the scriptable object variables. Index is made using the count-1
            PlacedBuildings.Add(new StoredBuildings(PlacedBuildings.Count, dataBase.objectDataBases[index].Type, 
                                                                            dataBase.objectDataBases[index].GenerationAmount,
                                                                            dataBase.objectDataBases[index].GenerationTime));
        }

    }
}



// This entire section will be filled out by the scriptable object
// Though the index will be filled out automatically
[System.Serializable]
public class StoredBuildings{
    public int index;
    public string Type;
    public float GenerationAmount;
    public float GenerationTime;

    public StoredBuildings(int  index, string Type, float GenerationAmount, float GenerationTime){
        this.index = index;
        this.Type = Type;
        this.GenerationAmount = GenerationAmount;
        this.GenerationTime = GenerationTime;
    } 
}