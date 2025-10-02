using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOnboarding : MonoBehaviour
{
    public static MapOnboarding instance;

    float timeToDestroy = 10f;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        timeToDestroy -= Time.deltaTime;

        if(timeToDestroy<= 0)
        {
            Destroy(gameObject);
        }
        
    }
}
