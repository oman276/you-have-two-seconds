﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCanvas : MonoBehaviour
{
    public static DeathCanvas instance;

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
}
