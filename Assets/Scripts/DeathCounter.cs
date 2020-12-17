using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathCounter : MonoBehaviour
{
    public static int deathsTotal = 0;
    public static int deathsOnLevel = 0;
    private Text deathTB;
    public static int ActiveScene;
    public bool isAtEnd;
    public bool newLevel = true;
    public static int numOfSkips = 0;

    public EndScreen endScreen;

    public static DeathCounter instance;

    void Awake()
    {

        
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        
        
    }


    public void PlayerDeath()
    {

        deathsTotal += 1;
        print("Deaths total: " + deathsTotal);


        deathsOnLevel += 1;
        print("Deaths on level: " + deathsOnLevel);

        if(deathsOnLevel >= 6)
        {
            //skipLevelButton.gameObject.SetActive(true);
        }
    }

    public void LevelDone()
    {
        print("Level Done Triggered");
        deathsOnLevel = 0;
    }

    public void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 27)
        {
            if (isAtEnd == false)
            {
                endScreen = FindObjectOfType<EndScreen>();
                endScreen.GetDeaths(deathsTotal);
                endScreen.GetSkips(numOfSkips);
                isAtEnd = true;
                deathsTotal = 0;
                numOfSkips = 0;
            }
        }

        else
        {
            isAtEnd = false;
        }

        if(deathsOnLevel >= 10)
        {
            ActiveScene = SceneManager.GetActiveScene().buildIndex;
            print(ActiveScene);
            SceneManager.LoadScene(28);
            deathsOnLevel = 0;
        }
    }


    public void SkipLevel()
    {
        print("Pressed1");
        numOfSkips++;
        SceneManager.LoadScene(ActiveScene + 1);
    }

    public void GoBack()
    {
        print("pressed2");
        SceneManager.LoadScene(ActiveScene);
    }
}
