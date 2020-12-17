using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public int numOfDeaths;
    public int numOfSkips;
    public Text deathText;
    public Text skipText;
    

    public void GetDeaths(int deaths)
    {
        print("The script got " + deaths + "deaths.");
        deathText.text = (deaths.ToString() + " Deaths");

    }

    public void GetSkips(int skips)
    {
        print("The Skip script got " + skips + "Skips");
        skipText.text = (skips.ToString() + " Skips");
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        print("Quitting");
        Application.Quit();

    }
}
