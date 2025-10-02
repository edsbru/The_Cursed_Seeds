using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceScaleOne : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.one;
        
    }

    private void FixedUpdate()
    {
        transform.localScale = Vector3.one;
    }
    private void OnAnimatorIK(int layerIndex)
    {
        transform.localScale = Vector3.one;
    }

    private void OnAnimatorMove()
    {
        transform.localScale = Vector3.one;
    }
}
