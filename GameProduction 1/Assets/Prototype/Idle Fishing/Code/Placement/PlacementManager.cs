using UnityEngine;

public class PlacementManager : MonoBehaviour
{

    /// <summary>
    /// 
    /// 2D box collider off side of the pier
    /// Give it a tag
    /// If the tag is a placement
    /// 
    /// </summary>

    [Header("Script References")]
    public GameObject MoneyManager;

    [Header("Prefabs")]
    public GameObject PierPrefab;
    public GameObject FisherPrefab;
    
    void Start()
    {

    }

    void Update()
    {

        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hit.collider.CompareTag("NewPierBlock") && MoneyManager.GetComponent<MoneyManager>().Money >= 100){
                MoneyManager.GetComponent<MoneyManager>().Money -= 100;

                GameObject Pier = Instantiate(PierPrefab, hit.collider.bounds.center, Quaternion.identity);

                Destroy(hit.collider.gameObject);
            }

            if(hit.collider.CompareTag("PierSlot") && MoneyManager.GetComponent<MoneyManager>().Money >= 10){
                MoneyManager.GetComponent<MoneyManager>().Money -= 10;

                GameObject Fisher = Instantiate(FisherPrefab, hit.collider.bounds.center, Quaternion.identity);

                Destroy(hit.collider.gameObject);
            }
        }

    }
}