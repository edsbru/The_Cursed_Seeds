using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropagateBubbleExplosion : MonoBehaviour
{
    public BubbgleScript bubble;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            bubble.Explode();
        }
    }
}
