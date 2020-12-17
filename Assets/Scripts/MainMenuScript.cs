using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        FindObjectOfType<AudioController>().Play("ButtonPress");
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        FindObjectOfType<AudioController>().Play("ButtonPress");
        print("Quit!");
        Application.Quit();
    }

}
