using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("Main UI")]
    public GameObject ShopMain;
    public GameObject ShopButton;

    [Header("Part 2 UI")]
    public GameObject TwoStoreSelectionHolder;
    public GameObject FishersMain;
    public GameObject PiersMain;

    // BOOLS
    [Header("Bools")]
    public bool FisherMenu = false;
    public bool PierMenu = false;
    public bool IsShopOpen = false;

    // Open shop menu
    // Player selects what they want to buy
    // Close the tab once they have selected what they want
    // Show nessecary purchase slots
    // Also allow players to cancel out of this part
    // Once player clicks on a slot
    // That slot is bought using the currently selected shop item

    public void OpenShop(){
        ShopMain.SetActive(true);
        TwoStoreSelectionHolder.SetActive(true);
        ShopButton.SetActive(false);
        IsShopOpen = true;
    }

    public void CloseMenu(){
        // Also need to hide the specific menus so that the menu can be re opened
        FishersMain.SetActive(false);
        ShopMain.SetActive(false);
        ShopButton.SetActive(true);

        IsShopOpen = false;
    }

    public void OpenFisherMenu(){
        // Hide eachothers buttons
        TwoStoreSelectionHolder.SetActive(false);
        FishersMain.SetActive(true);

        FisherMenu = true;
    }

    public void OpenPierMenu(){
        // Hide eachothers buttons
        TwoStoreSelectionHolder.SetActive(false);
        PiersMain.SetActive(true);

        PierMenu = true;
    }

    // Hard coded buttons not the best but cheesing is easier for a prototype
    public bool Fisher1Bool;
    public bool Fisher2Bool;

    // small objects ppl
    public void Fisher1(){
        Fisher1Bool = true;
        
        CloseMenu();
    }

    // Large objects. Boats
    public void Fisher2(){
        Fisher2Bool = true;

        CloseMenu();
    }

    public bool Pier1Bool;
    public bool Pier2Bool;

    public void Pier1(){
        Pier1Bool = true;

        CloseMenu();
    }

    public void Pier2(){
        Pier2Bool = true;

        CloseMenu();
    }
}
