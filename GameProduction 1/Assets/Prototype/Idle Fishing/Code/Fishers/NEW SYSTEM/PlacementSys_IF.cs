using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// What this script will do?
/// 
/// - Control placements and buying slots
/// 
/// </summary>

public class PlacementSys_IF : MonoBehaviour
{
    [Header("Scripts")]
    public BuyScriptables_IF buyScriptables_IF;
    public MoneyManager moneyManager;

    [Header("Menus")]
    public bool isMenuOpen = false;
    public GameObject backButton;
    public GameObject smallFisherMenu;
    public GameObject largeFisherMenu;
    public GameObject pierMenu;

    [Header("Current Selection")]
    public RaycastHit2D hit;
    public Transform CurrentSelection;

    public void Update(){
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);


        // If it hits something...
        if (Input.GetMouseButtonDown(0) && hit && !isMenuOpen)
        {

            if(hit.transform.tag == "SmallPierSlot"){
                CurrentSelection = hit.transform;
                //Debug.Log("Pressed small pier slot");
                CloseMenus();

                backButton.SetActive(true);

                OpenSmallFisher();
            }

            if(hit.transform.tag == "LargePierSlot"){
                //Debug.Log("Pressed small pier slot");
                CurrentSelection = hit.transform;
                CloseMenus();

                backButton.SetActive(true);

                OpenLargeFisher();
            }

            if(hit.transform.tag == "NewPierBlock"){
                CurrentSelection = hit.transform;
                //Debug.Log("Pressed new pier");
                CloseMenus();

                backButton.SetActive(true);

                OpenPier();
            }
        }
    }

    public void ItemToBuy(int index){

        if(buyScriptables_IF.storeItem[index].itemType == "pier"){
            // Spawn the item on the current selection CurrentGO

            Transform PlacementOffset = hit.transform.Find("BuyNewPier");

            GameObject Clone = Instantiate(buyScriptables_IF.storeItem[index].GOPrefab);

            // Offset the gameobject
            Clone.transform.position = PlacementOffset.position;

            // Remove the money
            moneyManager.Money -= buyScriptables_IF.storeItem[index].ItemCost;

            CloseMenus();
        }

        if(buyScriptables_IF.storeItem[index].itemType == "fisher"){

            GameObject Clone = Instantiate(buyScriptables_IF.storeItem[index].GOPrefab);

            // Offset the gameobject
            Clone.transform.position = CurrentSelection.position;

            // Remove the money
            moneyManager.Money -= buyScriptables_IF.storeItem[index].ItemCost;

            // Hide the sprite
            CurrentSelection.transform.gameObject.SetActive(false);

            CloseMenus();
        }
    }


    void OpenSmallFisher(){
        // This will open the small fisher menu

        smallFisherMenu.SetActive(true);
        isMenuOpen = true;
    }

    void OpenLargeFisher(){
        // This will open the menu for boats
        
        largeFisherMenu.SetActive(true);
        isMenuOpen = true;
    }

    void OpenPier(){
        // This is opened when the player clicks on 

        pierMenu.SetActive(true);
        isMenuOpen = true;
    }

    public void CloseMenus(){
        // Close everything
        backButton.SetActive(false);

        smallFisherMenu.SetActive(false);
        largeFisherMenu.SetActive(false);
        pierMenu.SetActive(false);

        isMenuOpen = false;
    } 
}
