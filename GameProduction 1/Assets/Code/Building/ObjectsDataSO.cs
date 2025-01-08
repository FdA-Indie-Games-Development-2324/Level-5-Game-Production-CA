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

    [Header("In game stats")]
    [Tooltip("Building Level = 1")]
    public int BuildingLevel;

    [Tooltip("How much XP the player should gain per placement")]
    public float XPGain;

    [Tooltip("Basic requirements needed to level up (The script does the rest)")]
    public float RequiredGold;
    public float RequiredResources;

    [Space(10)]

    [Tooltip("The time it takes to create the building")]
    public float TimeToBuild;
    [Tooltip("The time it takes to destroy the building")]
    public float TimeToDestroy;

    [Header("IF resource generator")]
    [Tooltip("These are base stats")]
    public float GenerationAmount;
    public float GenerationTime;

    [Header("Prefab to spawn")]
    public GameObject Prefab;
}