using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.Port;

public class DeathRedAnimation : MonoBehaviour
{

    float opacity = 0f;

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<PlayerHealthHandler>().playerStats.life <= 0)
        {
            opacity += Time.deltaTime * 0.5f / 5f;
            opacity = Mathf.Min(opacity, 0.5f);

            Color c = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, opacity);

        }
        transform.position = FindObjectOfType<PlayerHealthHandler>().transform.position;
    }
}
