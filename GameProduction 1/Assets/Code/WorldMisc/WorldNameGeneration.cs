using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WorldNameGeneration : MonoBehaviour
{
    /// <summary>
    /// All of the names are all generated via AI (Gemini) 
    /// 
    /// This will just show the set name
    /// 
    /// 1. Generate name
    /// 2. Wait for the level to be generated
    /// 3. Activate the Introduction text
    /// 4. Wait a couple seconds
    /// 5. Fade text away and hide
    /// 
    /// </summary>
    

    [Header("World names")]
    public TMP_Text IntroductionText;
    public List<string> PossibleNames;
    public string TownName;

    [Header("Script references")]
    public LoadingScreenManager loadingScreenManager;

    
    void Start()
    {
        TownName = Random.Range(0, PossibleNames.Count).ToString();
        IntroductionText.text = "Welcome to " + TownName;
    }

    void Update(){
        if(loadingScreenManager.IsGenerationComplete){
            StartCoroutine(ShowText());
        }
    }

    IEnumerator ShowText(){
        yield return new WaitForSeconds(2.5f);
        
        // Active the text here. The animation will already be done through the SimpleAnimations.cs
        IntroductionText.GetComponent<SimpleAnimations>().FadeIntoView();
        
        yield return new WaitForSeconds(5f);

        // Starting out the fade out
        IntroductionText.GetComponent<SimpleAnimations>().FadeOutView();

        // Give is the amount of time it takes to fade out. This will then move down the bit below.
        yield return new WaitForSeconds(IntroductionText.GetComponent<SimpleAnimations>().timeToFadeOutCol);

        // Finally disabling the GO
        IntroductionText.gameObject.SetActive(false);
    }
}
