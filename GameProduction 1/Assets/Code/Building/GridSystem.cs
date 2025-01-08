using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    [Header("Grid")]
    public int x_Width;
    public int z_Width;
    public GameObject GridPoint;
    public GameObject GridPointParent;

    [Header("Grid data")]
    public List<GameObject> GridData;

    #region Layout of the grid
    public void Start()
    {
        GridLayout();
        StartCoroutine(TreeGeneration());
    }

    void GridLayout(){
        for (int x = 0; x < x_Width; x++)
        {
            for (int z = 0; z < z_Width; z++)
            {
                // Need to instantiate points
                GameObject Tile = Instantiate(GridPoint, new Vector3(x, 0, z), Quaternion.identity, GridPointParent.transform);
                GridData.Add(Tile);
            }
        }
    }
    #endregion


    #region Random generation

    [Header("Random Generation")]
    // Density shouldnt go above the amount of points in the griddata
    public int TreeDensity;
    public GameObject[] TreePrefabs;
    public GameObject TreeParent;
    public bool CompletedTrees;


    public int RockDensity;
    public GameObject[] RockPrefabs;
    public GameObject RockParent;
    public bool CompletedRocks;


    public int BushDensity;
    public GameObject[] BushPrefabs;
    public GameObject BushParent;
    public bool CompletedBush;


    public int RuinsDensity;
    public GameObject[] RuinsPrefabs;
    public GameObject RuinsParent;
    public bool CompletedRuins;


    // Used for checking
    float objSpawned;
    public float TreeCurrentPercent;
    public float RockCurrentPercent;
    public float BushesCurrentPercent;
    public float RuinsCurrentPercent;


    /// <summary>
    /// I need a overall float to be met. In this case there is 4 different things to generate.
    /// This means that technically it loads 400% so I can put a final value off that
    /// </summary>
    /// <returns></returns>
    

    #endregion


    #region Trees
    IEnumerator TreeGeneration(){
        
        // Loop through all of the points select random one
        // This I will not write about multiple times

        for (int i = 0; i < TreeDensity; i++)
        {
            // random game object from the list
            var RandomGO = Random.Range(0, TreePrefabs.Length);
            
            // Random rotation in Y
            Quaternion RandomY = Quaternion.Euler(0, Random.Range(0, 360), 0);

            // Random scale
            float randScale = Random.Range(.9f, 1.3f);
            TreePrefabs[RandomGO].transform.localScale = new Vector3(randScale, randScale, randScale);
            
            // random grid pos from list
            var RandomPos = Random.Range(0, GridData.Count);

            // This will create a quick OverlapSphere at the location to check if the placement is valid
            Collider[] cols = Physics.OverlapSphere(GridData[RandomPos].transform.position, 1);

            // If the detected colliders is above 1 then the placement is invalid. 
            // I am passing 1 because the ground is a collider that will be detected
            if(cols.Length > 1){
                //Debug.LogWarning("Invalid Tree Placement");

                // Adding +1 onto the bush density will allow the script to try again at placing this tree but in a valid point
                BushDensity += 1;
            } else{
                // Else if there is only 1 collider detected (the ground) Spawn asset at this point
                GameObject RandomWorld = Instantiate(TreePrefabs[RandomGO], GridData[RandomPos].transform.position, RandomY, TreeParent.transform);
            }

            // This will be used
            objSpawned++;
            TreeCurrentPercent = objSpawned/TreeDensity * 100;
            //Debug.Log(TreeCurrentPercent);
            
            yield return new WaitForEndOfFrame();
        }

        //StaticBatchingUtility.Combine(TreeParent);

        if(TreeCurrentPercent == 100){
            //Debug.Log("Tree generation completed");
            CompletedTrees = true;
            objSpawned = 0;

            StartCoroutine(RockGeneration());
        }

        // Using this should prevent peoples devices from crashing.
        // This will wait until the end of the frame and then continue to the next frame
        // without this and within say a update() this will just run through the script
        // with the amount of FPS the game is getting and when spawning many objects
        // this will crash the scene with near immediate effect.

    }
    #endregion

    #region Rocks
    IEnumerator RockGeneration(){

        for (int i = 0; i < RockDensity; i++)
        {
            // random game object from the list
            var RandomGO = Random.Range(0, RockPrefabs.Length);
            
            // Random rotation in Y
            Quaternion RandomY = Quaternion.Euler(0, Random.Range(0, 360), 0);

            // Random scale
            float randScale = Random.Range(.9f, 1.3f);
            RockPrefabs[RandomGO].transform.localScale = new Vector3(randScale, randScale, randScale);
            
            // random grid pos from list
            var RandomPos = Random.Range(0, GridData.Count);


            // This will create a quick OverlapSphere at the location to check if the placement is valid
            Collider[] cols = Physics.OverlapSphere(GridData[RandomPos].transform.position, 1);

            // If the detected colliders is above 1 then the placement is invalid. 
            // I am passing 1 because the ground is a collider that will be detected
            if(cols.Length > 1){
                //Debug.LogWarning("Invalid Rock Placement");

                // Adding +1 onto the bush density will allow the script to try again at placing this tree but in a valid point
                BushDensity += 1;
            } else{
                // Else if there is only 1 collider detected (the ground) Spawn asset at this point
                GameObject RandomWorld = Instantiate(RockPrefabs[RandomGO], GridData[RandomPos].transform.position, RandomY, RockParent.transform);
            }

            objSpawned++;
            RockCurrentPercent = objSpawned/RockDensity * 100;
            //Debug.Log(currentPercent);
            
            yield return new WaitForEndOfFrame();
        }

        //StaticBatchingUtility.Combine(RockParent);

        if(RockCurrentPercent == 100){
            //Debug.Log("Rock generation completed");
            CompletedRocks = true;
            objSpawned = 0;
            RockCurrentPercent = 0;

            StartCoroutine(BushGeneration());
        }

    }
    #endregion

    #region Bushes
    IEnumerator BushGeneration(){

        for (int i = 0; i < BushDensity; i++)
        {
            // random game object from the list
            var RandomGO = Random.Range(0, BushPrefabs.Length);
            
            // Random rotation in Y
            Quaternion RandomY = Quaternion.Euler(0, Random.Range(0, 360), 0);

            // Random scale
            float randScale = Random.Range(.3f, .7f);
            BushPrefabs[RandomGO].transform.localScale = new Vector3(randScale, randScale, randScale);
            
            // random grid pos from list
            var RandomPos = Random.Range(0, GridData.Count);


            // This will create a quick OverlapSphere at the location to check if the placement is valid
            Collider[] cols = Physics.OverlapSphere(GridData[RandomPos].transform.position, 1);

            // If the detected colliders is above 1 then the placement is invalid. 
            // I am passing 1 because the ground is a collider that will be detected
            if(cols.Length > 1){
                //Debug.LogWarning("Invalid Bush Placement");

                // Adding +1 onto the bush density will allow the script to try again at placing this tree but in a valid point
                BushDensity += 1;
            } else{
                // Else if there is only 1 collider detected (the ground) Spawn asset at this point
                GameObject RandomWorld = Instantiate(BushPrefabs[RandomGO], GridData[RandomPos].transform.position, RandomY, BushParent.transform);
            }




            objSpawned++;
            BushesCurrentPercent = objSpawned/BushDensity * 100;
            //Debug.Log(currentPercent);
            
            yield return new WaitForEndOfFrame();
        }

        //StaticBatchingUtility.Combine(BushParent);

        if(BushesCurrentPercent == 100){
            //Debug.Log("Rock generation completed");
            CompletedBush = true;
            objSpawned = 0;
            BushesCurrentPercent = 0;

            StartCoroutine(RuinsGeneration());
        }

    }
    #endregion

    #region Ruins
    IEnumerator RuinsGeneration(){

        for (int i = 0; i < RuinsDensity; i++)
        {
            // random game object from the list
            var RandomGO = Random.Range(0, RuinsPrefabs.Length);
            
            // Random rotation in Y
            Quaternion RandomY = Quaternion.Euler(0, Random.Range(0, 360), 0);

            // Random scale
            float randScale = Random.Range(.9f, 1.3f);
            RuinsPrefabs[RandomGO].transform.localScale = new Vector3(randScale, randScale, randScale);
            
            // random grid pos from list
            var RandomPos = Random.Range(0, GridData.Count);

            // This will create a quick OverlapSphere at the location to check if the placement is valid
            Collider[] cols = Physics.OverlapSphere(GridData[RandomPos].transform.position, 1);

            // If the detected colliders is above 1 then the placement is invalid. 
            // I am passing 1 because the ground is a collider that will be detected
            if(cols.Length > 1){
                //Debug.LogWarning("Invalid Ruins Placement");

                // Adding +1 onto the bush density will allow the script to try again at placing this tree but in a valid point
                BushDensity += 1;
            } else{
                // Else if there is only 1 collider detected (the ground) Spawn asset at this point
                GameObject RandomWorld = Instantiate(RuinsPrefabs[RandomGO], GridData[RandomPos].transform.position, RandomY, RuinsParent.transform);
            }

            //Debug.Log("Generated ruin");

            objSpawned++;
            RuinsCurrentPercent = objSpawned/RuinsDensity * 100;
            //Debug.Log(currentPercent);
            
            yield return new WaitForEndOfFrame();
        }

        //StaticBatchingUtility.Combine(RuinsParent);


        if(RuinsCurrentPercent == 100){
            //Debug.Log("Ruin generation completed");
            CompletedRuins = true;
            objSpawned = 0;
            RuinsCurrentPercent = 0;
            
        }

        // Now start the game 
        
    }
    #endregion

}