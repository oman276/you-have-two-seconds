using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    public PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
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
