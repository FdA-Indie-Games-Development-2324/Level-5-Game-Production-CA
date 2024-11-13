using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class NewObjectsDataSO : ScriptableObject
{
    public List<NewObjectDataBase> objectDataBases;
}

[Serializable]
public class NewObjectDataBase{
    public string Name;
    public int ID;
    public GameObject Prefab;
}