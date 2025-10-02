using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossDoorData : MonoBehaviour
{
    [SerializeField] public AudioClip sound;
    public static CrossDoorData instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
