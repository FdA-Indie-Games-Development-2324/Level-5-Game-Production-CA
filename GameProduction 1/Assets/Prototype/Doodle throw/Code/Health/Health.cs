using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public int AmountOfJumps = 2;
    public TMP_Text ThrowText;

    void Update()
    {
        ThrowText.text = "Jumps left: " + AmountOfJumps.ToString();

        if(AmountOfJumps <= 0){
            Debug.Log("Game over");
        }
    }
}
