using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [Header("Stored Houses")]
    public List<GameObject> PlacedBuildings = new();
    public List<GameObject> PlacedShops = new();
    public NewPlacement BuildingPlacement;
}
