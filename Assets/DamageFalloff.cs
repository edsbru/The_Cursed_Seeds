using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DamageFalloff : MonoBehaviour
{
    float minDist = 0.5f;
    float maxDist = 4f;
    Vector2 initialPos;
    float initialDamage;
    float minDamage;
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        initialDamage = GetComponent<BulletStats>().damage;
        minDamage = initialDamage * 0.2f;
        //lastPosition = initialPos;
    }


    //Vector2 lastPosition = Vector2.zero;
    // Update is called once per frame
    void FixedUpdate()
    {
        float distance = Vector2.Distance(initialPos, transform.position);

        if(distance < minDist )
        {
            GetComponent<BulletStats>().damage = initialDamage;
        }
        else if(distance > maxDist )
        {
            GetComponent<BulletStats>().damage = minDamage;

        }else
        {
            float state = (distance-minDist) / (maxDist-minDist);
            GetComponent<BulletStats>().damage = (1f-state) * initialDamage + (state)*minDamage;

        }

        //Debug.Log(GetComponent<BulletStats>().damage);
        //Debug.DrawLine(lastPosition, transform.position, new Color(1, 0, 0, GetComponent<BulletStats>().damage), 10f);
        //lastPosition = transform.position;
    }
}
