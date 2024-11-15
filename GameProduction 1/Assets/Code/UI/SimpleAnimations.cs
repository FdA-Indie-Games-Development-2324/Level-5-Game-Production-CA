using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleAnimations : MonoBehaviour
{
    void OnEnable(){
        if(FadeToBlack){
            FadeScreen();
        }

        if(FadeToAlpha){
            FadeOutScreen();
        }

        if(FadeIntoText || FadeIntoImage){
            FadeIntoView();
        }

        if(RotateThisObj){
            LoopRotation();
        }
    }

    void OnDisable(){
        DOTween.Kill(transform);
    }



    [Header("Panel hiding")]
    public RectTransform Panel;
    public Vector2 HiddenPos;
    public Vector2 UnHiddenPos;
    public float TimeToMove;
    public bool isToggleOn = true;

    public void PanelMoving(bool isPanelOpen){
        // if Panel is currently hidden move to be none hidden
        if(isPanelOpen){
            Panel.DOAnchorPos(UnHiddenPos, TimeToMove);
            Debug.Log("Opened");
        }
        else{   
            Panel.DOAnchorPos(HiddenPos, TimeToMove);
            Debug.Log("Closed");
        }
        isToggleOn = isPanelOpen;
    }


    [Header("Fade to black")]
    public bool FadeToBlack;
    public Color MaxAlpha;
    public float timeToFade;

    public void FadeScreen(){
        GetComponent<Image>().DOColor(MaxAlpha, timeToFade);
    }

    [Header("Fade to alpha")]
    public bool FadeToAlpha;
    public Color MinAlpha;
    public float timeToDisappear;

    public void FadeOutScreen(){
        GetComponent<Image>().DOColor(MinAlpha, timeToDisappear);
    }

    [Header("Fade into view")]
    public bool FadeIntoText;
    public bool FadeIntoImage;
    public Color FadeToColour;
    public float timeToFadeToCol;

    public void FadeIntoView(){
        if(FadeIntoText){
            GetComponent<TMP_Text>().DOColor(FadeToColour, timeToFadeToCol);
        }

        if(FadeIntoImage){
            GetComponent<Image>().DOColor(FadeToColour, timeToFadeToCol);
        }
    }

    [Header("Fade out of view")]
    public bool FadeOutText;
    public bool FadeOutImage;
    public Color FadeOutColour;
    public float timeToFadeOutCol;

    public void FadeOutView(){
        if(FadeOutText){
            GetComponent<TMP_Text>().DOFade(0, timeToFadeOutCol);
        }

        if(FadeOutImage){
            GetComponent<Image>().DOColor(FadeToColour, timeToFadeOutCol);
        }
    }

    [Header("Simple rotation Looped")]
    public bool RotateThisObj;
    public Vector3 rot = new Vector3(360,0,0);
    public float TimeToRotate;

    public void LoopRotation(){
        transform.DORotate(rot, 2f, RotateMode.Fast).SetLoops(-1).SetEase(Ease.Linear);
        Debug.Log("Is rotating");
    }
    
}
