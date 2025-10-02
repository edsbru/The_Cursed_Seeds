using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotOnboarding : MonoBehaviour
{

    public static ShotOnboarding instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        var projectiles = FindObjectsOfType<BulletStats>();

        for (int i = 0; i < projectiles.Length; i++)
        {
            if (projectiles[i].tag != "enemyB")
            {
                Destroy(this.gameObject);
            }
        }
        
    }
}
