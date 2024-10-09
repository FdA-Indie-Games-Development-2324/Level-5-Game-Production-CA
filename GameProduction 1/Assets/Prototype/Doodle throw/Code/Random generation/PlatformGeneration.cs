using UnityEngine;

public class PlatformGeneration : MonoBehaviour
{

    /* TO DO:

    - Start out by spawning all of the platforms within the box
    - Check if there is a player currently within the box
    - If yes spawn next object above. This will be the same prefab as this object. This loops.
    - And add a bool to check if the player has entered.
    - If yes bool = true and so now when the player exits this box it will delete itself.

    */

    [Header("Values")]
    public int PlatformAmount = 5;

    /* 
    Come back to overlapping in a bit or on the full version as currently
    it wont be a massive issue but its something that will make the game
    more fair and playable 
    */
    public float Overlapping;
    Collider2D col;
    

    [Header("Prefabs")]
    public GameObject Platform;
    public GameObject ChunkPrefab;
    public Transform CentrePoint;

    Vector3 BoudingBoxSize;

    [Header("Bools")]
    public bool hasPlayerEntered;

    GameObject PlatformManager;

    void Start(){
        PlatformManager = GameObject.Find("LevelManager");
        Platform.GetComponent<PlatformManager>().NewPlatformSpawned = true;
        
        col = GetComponent<Collider2D>();
        for (int i = 0; i < PlatformAmount; i++)
        {
            Vector3 RandPoints = new Vector3(
            Random.Range(col.bounds.min.x, col.bounds.max.x),
            Random.Range(col.bounds.min.y, col.bounds.max.y),
            0
            );
            //Vector3 RandomPos = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(0, 10), 0);
            Object Clone = Instantiate(Platform, RandPoints, Quaternion.identity, this.transform);
        }
    }

    void OnTriggerEnter2D(){
        Debug.Log("Player has entered a new chunk");
        Vector3 Offset = new Vector3(0, col.bounds.max.y + 5.5f, 0);
        //Spawn another box above here
        Object NewChunk = Instantiate(ChunkPrefab, Offset, Quaternion.identity);
    }

    void OnDrawGizmos(){
        BoudingBoxSize = col.bounds.size;
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(col.bounds.center, BoudingBoxSize);
    }
}
