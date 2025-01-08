using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public float Money;
    public TMP_Text MoneyText;

    public void Update(){
        MoneyText.text = "Money: " + Money.ToString();
    }

    public void ClickForGold(){
        Money++; 
    }
}
