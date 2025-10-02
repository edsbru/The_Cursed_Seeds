using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchUIIndicator : MonoBehaviour
{
    public GameObject indicatorWhenPlayerOut;
    public GameObject indicatorWhenPlayerIn;

    private void Start()
    {
        indicatorWhenPlayerOut.SetActive(true);
        indicatorWhenPlayerIn.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            indicatorWhenPlayerOut.SetActive(false);
            if(gameObject.activeSelf)
                indicatorWhenPlayerIn.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (gameObject.activeSelf)
                indicatorWhenPlayerOut.SetActive(true);
            indicatorWhenPlayerIn.SetActive(false);
        }
    }
}
