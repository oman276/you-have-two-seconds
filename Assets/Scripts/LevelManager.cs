using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{

    private int currentLevel;

    public float explosionDelay = 0.1f;
    public float respawnDelay;
    public PlayerController gamePlayer;
    public DeathCounter deathCounter;




    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController>();
        deathCounter = FindObjectOfType<DeathCounter>();

    }


    public void Respawn()
    {
        deathCounter.PlayerDeath();
        StartCoroutine(RespawnCoroutine());
    }

    public IEnumerator RespawnCoroutine()
    {
        
        yield return new WaitForSeconds(explosionDelay);
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        deathCounter.LevelDone();
        FindObjectOfType<AudioController>().Play("LevelCompleteChime");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ButtonPress()
    {
        FindObjectOfType<AudioController>().Play("ButtonPress");
    }

}
