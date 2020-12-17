﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerText;
    private float startTime;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        float displayTime = 2 - t;

        if(displayTime <= 0)
        {
            displayTime = 0;
        }

        string seconds = (displayTime % 60).ToString("f2");
        timerText.text = seconds;
    }
}
