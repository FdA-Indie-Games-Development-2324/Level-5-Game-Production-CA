using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public List<GameObject> CurrentChunks = new List<GameObject>();
    public bool NewPlatformSpawned;

    void Update()
    {
        if(CurrentChunks.Count >= 4){
            Debug.Log("4th has been met now delete it");
            Destroy(CurrentChunks[0].gameObject);
            CurrentChunks.Remove(CurrentChunks[0]);
        }
    }
}
