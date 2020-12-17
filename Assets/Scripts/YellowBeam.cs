using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBeam : MonoBehaviour
{
    public PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerController.Die();
        }
    }
}
