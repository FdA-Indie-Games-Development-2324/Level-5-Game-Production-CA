using UnityEngine;

public class Fishers : MonoBehaviour
{
    float TimeToFish = 5;
    public float Min;
    public float Max;
    float AmountPerCatch;

    GameObject MoneyManagerOBJ;

    void Start(){
        MoneyManagerOBJ = GameObject.Find("MoneyManager");
    }

    void Update()
    {
        if(Time.time > TimeToFish){
            TimeToFish = Time.time + 5;

            MoneyManagerOBJ.GetComponent<MoneyManager>().Money += Mathf.FloorToInt(Random.Range(Min, Max));
        }
    }
}
