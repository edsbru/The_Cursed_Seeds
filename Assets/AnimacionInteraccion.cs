using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AnimacionInteraccion : MonoBehaviour
{
    float duration = 1.75f;
    float timeCount = 0f;
    public float offset = 0.18f;
    Vector2 origin;
    AnimationCurve curve;
    // Start is called before the first frame update
    void Start()
    {
        curve = new AnimationCurve();
        curve.keys = new Keyframe[]
        {
            new Keyframe(0f, 0f),
            new Keyframe(0.5f, 1f),
            new Keyframe(1f, 0f),
        };
        origin = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = origin + Vector2.up * curve.Evaluate(timeCount/duration) * offset;
        timeCount = (timeCount+Time.deltaTime) % duration;
    }
}
