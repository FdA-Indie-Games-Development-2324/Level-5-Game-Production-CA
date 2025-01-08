using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

/// <summary>
/// This is the container for all of the players money, levels and resources
/// </summary>

public class PlayerStatistics : MonoBehaviour
{
    public float Gold;
    public float Rescoure;
    public float Population;

    [Header("Levels")]
    public float TownLvl = 1;
    public float RequiredXP = 10;
    public float CurrentXPAmount;
    
    [Header("UI")]
    public TMP_Text GoldText;
    public TMP_Text ResourceText;
    public TMP_Text LevelText;
    public TMP_Text PopulationText;

    [Header("Town Hall")]
    public GameObject TownHall;


    [Header("Audio")]
    public AudioSource AudioPlayer;
    public AudioClip LevelUpSFX;

    void Start(){
        // Refresh all of the items from the Temp values
        RefreshGold();
        RefreshResource();
        RefreshPopulation();
    }


    void Update(){
        if(Input.GetKeyDown(KeyCode.C)){
            CurrentXPAmount += 5;

            CheckLevel();
        }
    }

    // Dont want to be updating everything per frame especially when other
    // scripts can do it for me

    public void RefreshGold(){
        if(Gold < 1000){
            GoldText.text = Gold.ToString();
        }
        else if(Gold > 1000){
            GoldText.text = Gold.ToString("D") + "k";
        }
        else if(Gold > 10000){
            GoldText.text = Gold.ToString("D") + "M";
        }
        else if(Gold > 100000){
            // Just incase
            GoldText.text = Gold.ToString("D") + "B";
        }

    }

    public void RefreshResource(){
        if(Rescoure < 1000){
            ResourceText.text = Rescoure.ToString();
        }
        else if(Rescoure > 1000){
            ResourceText.text = Rescoure.ToString("D") + "k";
        }
        else if(Rescoure > 10000){
            ResourceText.text = Rescoure.ToString("D") + "M";
        }
        else if(Rescoure > 100000){
            // Just incase
            ResourceText.text = Rescoure.ToString("D") + "B";
        }
    }

    public void RefreshPopulation(){
        PopulationText.text = Population.ToString();
    }


    void LevelUp(){
        // Play audio
        AudioPlayer.clip = LevelUpSFX;
        AudioPlayer.Play();

        TownLvl++;
        RequiredXP = Mathf.Round(RequiredXP * 1.3f);

        // Change the text in game
        LevelText.text = TownLvl.ToString();

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