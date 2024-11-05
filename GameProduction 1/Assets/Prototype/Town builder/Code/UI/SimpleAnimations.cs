using DG.Tweening;
using UnityEngine;

public class SimpleAnimations : MonoBehaviour
{
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
}
