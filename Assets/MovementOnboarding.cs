using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementOnboarding : MonoBehaviour
{

    Vector3 lastPos = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if(lastPos == Vector3.zero)
        {
            lastPos = FindObjectOfType<PlayerMovement>().transform.position;
        }else
        {
            if(lastPos != FindObjectOfType<PlayerMovement>().transform.position)
            {
                Destroy(this.gameObject);
            }
        }
            
    }
}
