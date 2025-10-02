using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotificateIfTal : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        
        GetComponent<SpriteRenderer>().enabled = GameManager.pendingToPillarArmaNueva && !FindObjectOfType<CofreArmas>().playerIn;    
    }
}
