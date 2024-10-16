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
    public GameObject ShopManager;
    

    void Update()
    {

        if(Input.GetMouseButtonDown(0) && ShopManager.GetComponent<ShopManager>().IsShopOpen == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hit.collider.CompareTag("SmallPierSlot") && ShopManager.GetComponent<ShopManager>().FisherMenu == true){
                
                if(ShopManager.GetComponent<ShopManager>().Fisher1Bool && MoneyManager.GetComponent<MoneyManager>().Money >= 125){
                    Debug.Log("Placed average fisher down");
                    Instantiate(ShopManager.GetComponent<ItemsContainer>().FishersPrefab1, hit.collider.transform.position, Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                    ShopManager.GetComponent<ShopManager>().FisherMenu = false;
                    ShopManager.GetComponent<ShopManager>().Fisher1Bool = false;
                }

            }

            if(hit.collider.CompareTag("LargePierSlot") && ShopManager.GetComponent<ShopManager>().FisherMenu == true){
                
                if(ShopManager.GetComponent<ShopManager>().Fisher2Bool && MoneyManager.GetComponent<MoneyManager>().Money >= 1200){
                    Debug.Log("Placed boat fisher down");
                    Instantiate(ShopManager.GetComponent<ItemsContainer>().FishersPrefab2, hit.collider.transform.position, Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                    ShopManager.GetComponent<ShopManager>().FisherMenu = false;
                    ShopManager.GetComponent<ShopManager>().Fisher2Bool = false;
                }

            }

            if(hit.collider.CompareTag("NewPierBlock") && ShopManager.GetComponent<ShopManager>().PierMenu == true){
                
                if(ShopManager.GetComponent<ShopManager>().Pier1Bool){
                    Debug.Log("Placed simple pier down");
                    Instantiate(ShopManager.GetComponent<ItemsContainer>().PiersPrefab1, hit.collider.transform.position, Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                    ShopManager.GetComponent<ShopManager>().PierMenu = false;
                    ShopManager.GetComponent<ShopManager>().Pier1Bool = false;
                }

                if(ShopManager.GetComponent<ShopManager>().Pier2Bool){
                    Debug.Log("Placed boat dock down");
                    Instantiate(ShopManager.GetComponent<ItemsContainer>().PiersPrefab2, hit.collider.transform.position, Quaternion.identity);
                    Destroy(hit.collider.gameObject);
                    ShopManager.GetComponent<ShopManager>().PierMenu = false;
                    ShopManager.GetComponent<ShopManager>().Pier2Bool = false;
                }

            }
        }

    }
}