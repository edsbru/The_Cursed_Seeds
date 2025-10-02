using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RecoverHealth : MonoBehaviour
{
    [SerializeField]
    public AudioClip healthClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (FindObjectOfType<PlayerStats>().life < 3)
            {
                SoundController.instance.PlaySound(healthClip);
                FindObjectOfType<PlayerStats>().life++;
                Destroy(this.gameObject);

                FindObjectOfType<PlayerHealthHandler>().UpdateLifeUI();
            }
        }
    }
}