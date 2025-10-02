using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClamperRenderer : MonoBehaviour
{
    private GameObject player;
    public SpriteRenderer sr;
    SpriteRenderer osr;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("mantee_v2");
        osr = transform.GetChild(transform.childCount - 1).GetComponent<SpriteRenderer>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
        osr.flipX = sr.flipX;
    }
}
