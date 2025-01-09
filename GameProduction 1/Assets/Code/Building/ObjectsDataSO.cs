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

    [Header("Requirements")]
    [Tooltip("This is used to call from buttons")]
    public int ID;

    [Tooltip("House or Shop (CASE SENSITIVE)")]
    public string Type;

    [Tooltip("This alters the size of the placement grid")]
    public Vector2 GridSize;

    [Header("Prefab to spawn")]
    public GameObject Prefab;
    public GameObject PreviewPrefab;
}