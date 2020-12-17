using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowLaser : MonoBehaviour
{
    private float startTime;
    private bool isActive;
    private float timer;
    public GameObject laser;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        laser.SetActive(false);
        isActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time - startTime;

        if(timer >= 0.5)
        {
            startTime = Time.time;
            if(isActive == false)
            {
                FindObjectOfType<AudioController>().Play("Electricity");
                laser.SetActive(true);
                isActive = true;
            }
            else
            {
                laser.SetActive(false);
                isActive = false;
            }
            
        }
    }
}
