using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is the container for all of the players money, levels and resources
/// </summary>

public class PlayerStatistics : MonoBehaviour
{
    public float Gold;
    public float Wood;

    [Header("Levels")]
    public float TownLvl = 1;
    public float RequiredXP = 10;
    public float CurrentXPAmount;
    [Space(10)]
    public AudioClip LevelUpSFX;
    
    [Header("Audio")]
    public AudioSource AudioPlayer;


    void Update(){
        if(Input.GetKeyDown(KeyCode.C)){
            CurrentXPAmount += 5;

            CheckLevel();
        }
    }

    void LevelUp(){
        // Play audio
        AudioPlayer.clip = LevelUpSFX;
        AudioPlayer.Play();

        TownLvl++;
        RequiredXP = Mathf.Round(RequiredXP * 1.3f);

        CurrentXPAmount = 0;
    }

    public void CheckLevel(){

        // Has the required level been met?
        if(CurrentXPAmount >= RequiredXP){
            Debug.Log("now leveled up");
            LevelUp();
        }
    }
}