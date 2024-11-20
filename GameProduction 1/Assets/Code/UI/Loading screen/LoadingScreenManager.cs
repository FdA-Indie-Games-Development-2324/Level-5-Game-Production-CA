using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text Header;
    public TMP_Text LoadingText;
    public TMP_Text PercentageText;
    public Image LoadingBar;

    [Header("Completed UI")]
    public GameObject BlackOut;

    [Header("Misc properties")]
    // Bool that will control whether the game has started
    public bool IsGenerationComplete;
    // Reference to the grid genrator
    public GridSystem gridSystem;
    // Max value
    public float MaxValue;
    // Current value
    public float CurrentValue;

    // Switch int
    public int CurrentState;

    void Awake(){
        MaxValue = 100;
        CurrentValue = 0;

        Debug.Log(MaxValue);
    }

    // Reference to the loading screen to disable once generated

    void Update(){

        switch (CurrentState)
        {
            case 0:
                TreeLoad();
            break;

            case 1:
                RockLoad();
            break;

            case 2:
                BushLoad();
            break;

            case 3:
                RuinLoad();
            break;

            case 4:
                //Debug.LogWarning("Loading has been completed");
            break;

            default:
                Debug.LogWarning("Out of range");
            break;
        }
    }

    #region Tree
    void TreeLoad(){
        // Change the text of the loading bar
        LoadingText.text = "Generating trees";
        PercentageText.text = gridSystem.TreeCurrentPercent.ToString("0") + "%";

        LoadingBar.fillAmount = gridSystem.TreeCurrentPercent / MaxValue;

        if(gridSystem.TreeCurrentPercent == MaxValue){
            // +1 onto the index. This will change the switch case to the next one
            CurrentState += 1;

            // Now need to reset the loading bar fill for the next generation
            LoadingBar.fillAmount = 0;
        }

    }
    #endregion

    #region Rock
    void RockLoad(){
        LoadingText.text = "Generating rocks";
        PercentageText.text = gridSystem.RockCurrentPercent.ToString("0") + "%";

        LoadingBar.fillAmount = gridSystem.RockCurrentPercent / MaxValue;

        if(gridSystem.RockCurrentPercent == MaxValue){
            CurrentState += 1;

            LoadingBar.fillAmount = 0;
        }
    }
    #endregion

    #region Bush
    void BushLoad(){
        LoadingText.text = "Generating foliage";
        PercentageText.text = gridSystem.BushesCurrentPercent.ToString("0") + "%";

        LoadingBar.fillAmount = gridSystem.BushesCurrentPercent / MaxValue;

        if(gridSystem.BushesCurrentPercent == MaxValue){
            CurrentState += 1;

            LoadingBar.fillAmount = 0;
        }
    }
    #endregion

    #region Ruin
    void RuinLoad(){
        float NewFloat = gridSystem.RuinsCurrentPercent * 10;
        LoadingText.text = "Generating ruins";
        PercentageText.text = NewFloat.ToString("0") + "%";


        LoadingBar.fillAmount = NewFloat / MaxValue;

        if(NewFloat == MaxValue){
            CurrentState += 1;

            IsGenerationComplete = true;

            LoadingBar.fillAmount = 0;

            StartCoroutine(FadeANDDisable());
        }
    }
    #endregion


    IEnumerator FadeANDDisable(){
        Header.text = "Starting game";

        // Change the text to done & also fade all of this text
        LoadingText.text = "Completed";
        
        if (IsGenerationComplete)
        {    
            // Fade out the backdrop
            BlackOut.GetComponent<SimpleAnimations>().FadeOutScreen();
            Header.GetComponent<SimpleAnimations>().FadeOutView();
            LoadingText.gameObject.SetActive(false);
            PercentageText.gameObject.SetActive(false);
            
            yield return new WaitForSeconds(BlackOut.GetComponent<SimpleAnimations>().timeToDisappear);

            BlackOut.transform.parent.transform.gameObject.SetActive(false);
        }
    }
}