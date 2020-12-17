using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    float dirX;
    public float moveSpeed = 3f;
    bool moveRight = true;
    public float rightLimit = 4f;
    public float leftLimit = -4f;


    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > rightLimit)
        {
            moveRight = false;
        }
        if(transform.position.x < leftLimit)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }



    }
}
