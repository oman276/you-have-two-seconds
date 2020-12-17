using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindDeathScore : MonoBehaviour
{
    public DeathCounter deathCounter;

    public Text deathText;
    string numOfDeaths;

    // Start is called before the first frame update
    void Start()
    {
        deathCounter = FindObjectOfType<DeathCounter>();
    }

}
