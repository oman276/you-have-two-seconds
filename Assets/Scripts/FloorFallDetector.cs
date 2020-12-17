using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFallDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Falling Floor")
        {
            FindObjectOfType<AudioController>().Play("FloorFall");
        }
    }
}
