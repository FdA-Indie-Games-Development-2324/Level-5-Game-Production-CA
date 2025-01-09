using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodMillScript : MonoBehaviour
{
    [Header("Base stats")]
    public int StructureLvl;

    public GameObject[] BuildingTiers;

    [Header("Generation")]
    public float TimeToGenerate = 2;
    public float ResourceGenerationAmount = 5;

    [Header("Audio")]
    public AudioSource audioSource;

    PlayerStatistics playerStatistics;
    bool CanGenerate;

    void Start()
    {
        playerStatistics = GameObject.Find("PlayerStats").GetComponent<PlayerStatistics>();

        StructureLvl = 1;
        StartCoroutine(BuildTime());
    }

    IEnumerator BuildTime(){
        yield return new WaitForSeconds(5);

        // Add XP here
        playerStatistics.CurrentXPAmount += 25;
        playerStatistics.CheckLevel();

        CanGenerate = true;

        StartCoroutine(GenerateResource());
    }

    IEnumerator GenerateResource(){
        audioSource.Play();
        
        while(CanGenerate){
            yield return new WaitForSeconds(TimeToGenerate);

            // Add resource here
            playerStatistics.Rescoure += ResourceGenerationAmount;
            playerStatistics.RefreshResource();
        }
    }

    public void LevelUpBuilding(){
        StructureLvl ++;

        // Increase the generation amount
        ResourceGenerationAmount += 5;

        // Decrease time to generate
        TimeToGenerate -= .1f;

        if(StructureLvl == 5){
            BuildingTiers[0].gameObject.SetActive(false);
            BuildingTiers[1].gameObject.SetActive(true);
        }
        else if(StructureLvl == 10){
            BuildingTiers[1].gameObject.SetActive(false);
            BuildingTiers[2].gameObject.SetActive(true);
        }
    }
}