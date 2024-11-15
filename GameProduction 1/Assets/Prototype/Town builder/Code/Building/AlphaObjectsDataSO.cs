using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class AlphaObjectsDataSO : ScriptableObject
{
    public List<AlphaObjectDataBase> AlphaobjectDataBases;
}

[Serializable]
public class AlphaObjectDataBase{
    public string Name;
    public int ID;
    public string Type;
    public GameObject Prefab;
}