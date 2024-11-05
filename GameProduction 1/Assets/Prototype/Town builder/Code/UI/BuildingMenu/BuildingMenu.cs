using UnityEngine;

public class BuildingMenu : MonoBehaviour
{
    public GameObject BuildingMenuUI, EnvironmentMenuUI;
    public void Buildings(){
        EnvironmentMenuUI.SetActive(false);
        BuildingMenuUI.SetActive(true);
    }

    public void Environments(){
        EnvironmentMenuUI.SetActive(true);
        BuildingMenuUI.SetActive(false);
    }
}
