using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLight : MonoBehaviour
{

    public Rigidbody2D rb;
    public bool isTriggered;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered == false)
        {
            rb.velocity = new Vector2(0, 0);
        }
        else
        {

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (isTriggered == false)
            {
                FindObjectOfType<AudioController>().Play("LightFall");
            }
            isTriggered = true;
        }
    }
}
