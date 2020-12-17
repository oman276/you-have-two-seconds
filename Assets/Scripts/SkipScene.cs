using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkipScene : MonoBehaviour
{
    public DeathCounter deathCounter;

    // Start is called before the first frame update
    void Start()
    {
        deathCounter = FindObjectOfType<DeathCounter>();
    }

    public void SkipLevel()
    {
        deathCounter.SkipLevel();
    }

    public void GoBack()
    {
        deathCounter.GoBack();
    }

}
