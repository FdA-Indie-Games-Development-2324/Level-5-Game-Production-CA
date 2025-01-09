using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHallScript : MonoBehaviour
{
    [Header("Building variants")]
    public GameObject[] TownHallTiers;


    PlayerStatistics playerStatistics;
    bool isBuilt;

    void Start()
    {
        isBuilt = false;
        StartCoroutine(BuildTime());

        playerStatistics = GameObject.Find("PlayerStats").GetComponent<PlayerStatistics>();
        playerStatistics.TownHall = gameObject;
        playerStatistics.TownHallTiers = TownHallTiers;
    }

    void Update()
    {
        
    }

    IEnumerator BuildTime(){
        yield return new WaitForSeconds(5);

        // Add XP here
        playerStatistics.CurrentXPAmount += 10;
        playerStatistics.CheckLevel();

        // Add coins to the player
        playerStatistics.Gold += 50;
        playerStatistics.RefreshGold();
    }
}
