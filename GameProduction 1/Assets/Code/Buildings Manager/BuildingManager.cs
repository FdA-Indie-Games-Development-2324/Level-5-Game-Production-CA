using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [Header("Stored Houses")]
    public List<GameObject> PlacedBuildings = new();
    public List<GameObject> PlacedShops = new();
    //public Placement BuildingPlacement;

    void Update(){
        //Debug.Log("apsdokapoksd");
    }

    void Houses(){

    }

    void Shops(){

    }

    public void AddHouse(){
        // should I create every object with a new id that is stored here. 
        // This is then used to store data about the building placed.
        // Editing would be easier as well
    }

    public void AddShop(){

    }
}
