using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGrid : MonoBehaviour
{
    [Header("Grid")]
    public int x_Width;
    public int z_Width;
    public GameObject GridPoint;

    [Header("Grid data")]
    public List<GameObject> GridData;

    #region Layout of the grid
    void Start()
    {
        GridLayout();
        StartCoroutine(RandomGeneration());
    }

    void GridLayout(){
        for (int x = 0; x < x_Width; x++)
        {
            for (int z = 0; z < z_Width; z++)
            {
                // Need to instantiate points
                GameObject Tile = Instantiate(GridPoint, new Vector3(x, 0, z), Quaternion.identity, transform);
                GridData.Add(Tile);
            }
        }
    }
    #endregion

    #region Random generation


    [Header("Random Generation")]
    // Density shouldnt go above the amount of points in the griddata
    public int Density;
    public GameObject[] RandomWorldPrefabs;
    public GameObject MapParentObject;

    // Used for checking
    float objSpawned;
    
    
    IEnumerator RandomGeneration(){
        // Loop through all of the points select random one
        for (int i = 0; i < Density; i++)
        {
            // random grid pos from list
            var RandomGO = Random.Range(0, RandomWorldPrefabs.Length);
            
            // Random rotation in Y
            Quaternion RandomY = Quaternion.Euler(0, Random.Range(0, 360), 0);

            // Random scale
            float randScale = Random.Range(.9f, 1.3f);
            RandomWorldPrefabs[RandomGO].transform.localScale = new Vector3(randScale, randScale, randScale);
            
            // random game object from the list
            var RandomPos = Random.Range(0, GridData.Count);
            // sapawn random gameobject on random point
            GameObject RandomWorld = Instantiate(RandomWorldPrefabs[RandomGO], GridData[RandomPos].transform.position, RandomY, MapParentObject.transform);

            // This will be used
            objSpawned++;
            float currentPercent = objSpawned/Density * 100;
            Debug.Log(currentPercent);

            // Using this should prevent peoples devices from crashing.
            // This will wait until the end of the frame and then continue to the next frame
            // without this and within say a update() this will just run through the script
            // with the amount of FPS the game is getting and when spawning many objects
            // this will crash the scene with near immediate effect.
            yield return new WaitForEndOfFrame();
        } 
    }

    void TreeGeneration(){

    }

    void RockGeneration(){

    }

    void RuinsGeneration(){
        
    }

    #endregion
}
