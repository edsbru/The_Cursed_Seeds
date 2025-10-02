using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSeeds : MonoBehaviour
{
    [SerializeField]
    public AudioClip popSound;
    public GameObject lifePrefab;
    public GameObject bubble;
    [SerializeField] private AudioClip pickSound;
    //public AudioSource picking;

    public static CollectSeeds instace;

    // Start is called before the first frame update
    void Start()
    {
        instace = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if  (collision.tag == "curency") {

           SoundController.instance.PlaySound(pickSound);
           Reference rf = collision.gameObject.GetComponent<Reference>(); 
            if (rf.ws.id_Wseed == 0)
            {
                GameManager.instance.inventory[0]++;
            }
            else if (rf.ws.id_Wseed == 1)
            {
                GameManager.instance.inventory[1]++;
            }
            Destroy(collision.gameObject);
        }
    }

}
