using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int AmountOfJumps;
    public TMP_Text ThrowText;

    void Update()
    {
        ThrowText.text = "Jumps left: " + AmountOfJumps.ToString();

        if(AmountOfJumps <= -1){
            Debug.Log("Game over");
            SceneManager.LoadScene("DoodleJumpThrow");
        }
    }
}
