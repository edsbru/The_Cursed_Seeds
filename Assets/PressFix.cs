using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressFix : MonoBehaviour
{

    public GameObject otherMessage;

    private void Update()
    {
        GetComponent<SpriteRenderer>().color = otherMessage.activeSelf?new Color(0,0,0,0):Color.white;
    }

}
