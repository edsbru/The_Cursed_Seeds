using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialOpenRoomTwo : MonoBehaviour
{
    public GameObject Bee_1;

    public GameObject Teleport;
    private Animator a;
    private BoxCollider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        Teleport = gameObject;
        a = Teleport.GetComponent<Animator>();
        coll = Teleport.GetComponent<BoxCollider2D>();

        a.enabled = false;
        coll.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Bee_1 == null)
        {
            a.enabled = true;
            coll.enabled = true;
        }else
        {

            a.enabled = false;
            coll.enabled = false;
        }
    }
}
