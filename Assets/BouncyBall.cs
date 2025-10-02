using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BouncyBall : MonoBehaviour
{
    int bounceCount = 0;

    Rigidbody2D rb;

    [SerializeField]
    public AudioClip bounceSound;

    float timeCounter = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        timeCounter += Time.deltaTime;
        if(timeCounter > 5f)
        {
            Destroy(gameObject);
        }

        if (rb.velocity.magnitude < GetComponent<BulletStats>().speed) {
        
            rb.velocity = rb.velocity.normalized * GetComponent<BulletStats>().speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        GetComponent<AudioSource>().PlayOneShot(bounceSound);

        if(collision.gameObject.GetComponent<PlayerMovement>() || collision.gameObject.GetComponent<BouncyBall>())
        {
            return;
        }
        if(bounceCount++ >= 3 || collision.collider.CompareTag("enemy"))
        {
            Destroy(gameObject);
        }

      
    }
}
