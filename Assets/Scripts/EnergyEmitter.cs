using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyEmitter : MonoBehaviour
{

    public Transform firepoint;
    private float startTime;
    private float timer;

    public GameObject energyBallPrefab;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time - startTime;

        if(timer >= 0.8)
        {
            FindObjectOfType<AudioController>().Play("EnergyBlast");
            startTime = Time.time;
            Shoot();

        }
    }

    void Shoot()
    {
        print("Blam!");
        Instantiate(energyBallPrefab, firepoint.position, firepoint.rotation);
    }
}
