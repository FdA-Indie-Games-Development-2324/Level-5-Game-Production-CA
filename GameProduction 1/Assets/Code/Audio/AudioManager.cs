using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource Music;

    [Header("UI SFX")]
    public AudioSource MouseClick;
    public AudioSource MouseRollover;

    // Settings (possibly)

    // EventSystem calls
    public void PlayMouseClick(){
        MouseClick.Play();
    }

    public void PlayMouseRollover(){
        MouseRollover.Play();
    }

    public void PlayBTNSequence(){
        
    }
}
