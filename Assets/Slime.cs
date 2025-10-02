using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public int id;
    public int[] incompatibles;

    private void Start()
    {
        if (GameManager.instance.currentFloor == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            FindObjectOfType<PlayerStats>().slimed = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            FindObjectOfType<PlayerStats>().slimed = false;

    }

}
