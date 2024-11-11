using System;
using System.Collections.Generic;
using UnityEngine;

public class GridData
{
    Dictionary<Vector3Int, PlacementData> placedObjects = new();

    public void AddObjectAt(Vector3Int gridPosition, Vector2Int objectSize, int ID, int placeObjectIndex){

        List<Vector3Int> positionsToOccupy = CalculatePositions(gridPosition, objectSize);
        PlacementData data = new PlacementData(positionsToOccupy, ID, placeObjectIndex);

        foreach (var pos in positionsToOccupy)
        {
            if(placedObjects.ContainsKey(pos)){
                throw new Exception($"Dictionary already contains the cell position {ID}");
            }
            placedObjects[pos] = data;
        }
    }

    private List<Vector3Int> CalculatePositions(Vector3Int gridPosition, Vector2Int objectSize)
    {
        List<Vector3Int> returnVal = new();

        for (int x = 0; x < objectSize.x; x++)
        {
            for (int y = 0; y < objectSize.y; y++)
            {
                returnVal.Add(gridPosition + new Vector3Int(x,0,y));
            }
        }
        return returnVal;
    }

    public bool CanPlaceObjectAt(Vector3Int gridPosition, Vector2Int objectSize)
    {
        List<Vector3Int> positionToOccupy = CalculatePositions(gridPosition, objectSize);
        foreach (var pos in positionToOccupy)
        {
            if(placedObjects.ContainsKey(pos)){
                return false;
            }
        }
        return true;
    }
}

public class PlacementData{
    public List<Vector3Int> occupiedPositions;


    public int ID { get; private set; }
    public int PlaceObjectIndex { get; private set; }
    
    public PlacementData(List<Vector3Int> occupiedPositions, int id, int placeObjectIndex)
    {
        this.occupiedPositions = occupiedPositions;
        ID = id;
        PlaceObjectIndex = PlaceObjectIndex;
    }
}
