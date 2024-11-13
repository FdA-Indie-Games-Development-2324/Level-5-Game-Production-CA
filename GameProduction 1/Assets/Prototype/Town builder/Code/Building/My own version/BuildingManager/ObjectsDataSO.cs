using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ObjectsDataSO : ScriptableObject
{
    public List<ObjectDataBase> objectDataBases;
}

[Serializable]
public class ObjectDataBase{
    public string Name;
    public int ID;
    public string Type;
    public GameObject Prefab;
    public float MinRotation;
    public float MaxRotation;
    public Vector2Int Size = Vector2Int.one;

}