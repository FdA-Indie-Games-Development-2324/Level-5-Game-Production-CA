using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimpleButtons : MonoBehaviour
{
    [Header("")]
    public GameObject Loadingscreen;
    public void Play(){
        // Set loading screen to true
        // Animation on the loading screen will play
        Loadingscreen.SetActive(true);

        // Load the scene after the amount of time it
        // takes for the screen to turn black
        StartCoroutine(PlayScreen());
    }

    public void Options(){
        Debug.Log("Opened options screen");
    }

    public void Quit(){
        Debug.Log("Quit game");
        Application.Quit();
    }


    IEnumerator PlayScreen(){

        yield return new WaitForSeconds(Loadingscreen.GetComponent<SimpleAnimations>().timeToFade);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Opened game scene");
    }
}
