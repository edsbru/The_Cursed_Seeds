using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialInfiniteHealth : MonoBehaviour
{
    
    float timeToRegen = 1f;
    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<PlayerStats>().life < 2)
        {
            timeToRegen -= Time.deltaTime;
            if(timeToRegen <= 0)
            {
                FindObjectOfType<PlayerStats>().life++;
                timeToRegen = 1f;
            }
            
        }
    }
}
