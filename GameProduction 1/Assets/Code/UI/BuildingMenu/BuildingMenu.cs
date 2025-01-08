using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingMenu : MonoBehaviour
{
    // This is old code required for the alpha and beta
    public GameObject BuildingMenuUI, EnvironmentMenuUI;
    public void Buildings(){
        EnvironmentMenuUI.SetActive(false);
        BuildingMenuUI.SetActive(true);
    }

    public void Environments(){
        EnvironmentMenuUI.SetActive(true);
        BuildingMenuUI.SetActive(false);
    }


    [Header("UI sections")]
    public GameObject HouseMenu;
    public GameObject ResourcesMenu;
    public GameObject DecorationsMenu;

    public TMP_Text CurrentModeText;
    public GameObject[] HotbarSlots;
    public GameObject CurrentActivePanel;

    [Header("Script references")]
    public ObjectSelection objectSelection;

    [Header("Bools")]
    public bool CanSwitch;

    void Start(){
        ClearActive();
        CurrentHotbar(0);
        CanSwitch = true;
    }

    void Update(){
        // Keyboard shortcuts. Yucky but cant think of a way around as of now.
        #region Hotkeys
        if(CanSwitch)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                CurrentHotbar(0);
            }

            if(Input.GetKeyDown(KeyCode.Alpha2)){
                CurrentHotbar(1);
            }

            if(Input.GetKeyDown(KeyCode.Alpha3)){
                CurrentHotbar(2);
            }
            
            if(Input.GetKeyDown(KeyCode.Alpha4)){
                CurrentHotbar(3);
            }

            if(Input.GetKeyDown(KeyCode.Alpha5)){
                CurrentHotbar(4);
            }
        }
        #endregion
    }

    public void CurrentHotbar(int index){

        if(CanSwitch)
        {
            switch (index)
            {
                case 0:
                    ClearActive();
                    HotbarSlots[index].GetComponent<Button>().interactable = false;
                    CurrentActivePanel = HotbarSlots[index];
                    //Debug.Log("Preview mode");

                    objectSelection.NotHovering();

                    CurrentModeText.text = "Preview";
                    break;

                case 1:
                    ClearActive();
                    HotbarSlots[index].GetComponent<Button>().interactable = false;
                    CurrentActivePanel = HotbarSlots[index];
                    //Debug.Log("Editing mode");
                    objectSelection.EditMode = true;

                    CurrentModeText.text = "Edit";
                    break;

                case 2:
                    ClearActive();
                    HotbarSlots[index].GetComponent<Button>().interactable = false;
                    CurrentActivePanel = HotbarSlots[index];
                    //Debug.Log("Buildings menu");
                    HouseMenu.GetComponent<SimpleAnimations>().PanelMoving(true);

                    objectSelection.NotHovering();

                    CurrentModeText.text = "Shopping";
                    break;

                case 3:
                    ClearActive();
                    HotbarSlots[index].GetComponent<Button>().interactable = false;
                    CurrentActivePanel = HotbarSlots[index];
                    //Debug.Log("Resources menu");
                    ResourcesMenu.GetComponent<SimpleAnimations>().PanelMoving(true);

                    objectSelection.NotHovering();

                    CurrentModeText.text = "Shopping";
                    break;

                case 4:
                    ClearActive();
                    HotbarSlots[index].GetComponent<Button>().interactable = false;
                    CurrentActivePanel = HotbarSlots[index];
                    //Debug.Log("Decorations menu");
                    DecorationsMenu.GetComponent<SimpleAnimations>().PanelMoving(true);

                    objectSelection.NotHovering();

                    CurrentModeText.text = "Shopping";
                    break;

                default:
                    ClearActive();
                    //Debug.LogError("Out of index somehow");
                    break;
            }
        }
    }

    void ClearActive(){
        // Cheese way of doing this but the easiest

        for (int i = 0; i < HotbarSlots.Length; i++)
        {
            HotbarSlots[i].GetComponent<Button>().interactable = true;
        }
        
        CurrentActivePanel = null;

        HouseMenu.GetComponent<SimpleAnimations>().PanelMoving(false);
        ResourcesMenu.GetComponent<SimpleAnimations>().PanelMoving(false);
        DecorationsMenu.GetComponent<SimpleAnimations>().PanelMoving(false);
        
        objectSelection.EditMode = false;
    }
}