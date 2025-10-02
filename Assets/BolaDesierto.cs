using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaDesierto : MonoBehaviour
{
    [SerializeField]
    public AudioClip boingSound;
    Vector2 direction;
    Rigidbody2D rb;
    float speed = 2.5f;
    float minAngularRotation = 60f;
    // Start is called before the first frame update
    void Start()
    {

        if(GameManager.instance.currentFloor == 0)
        {
            Destroy(gameObject);
        }else if(GameManager.instance.currentFloor >= 2)
        {
            speed *= 2f;
            minAngularRotation *= 2f;
        }

        direction = new Vector2 (
        Random.Range(-1f,1f), Random.Range(-1f, 1f)).normalized;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = direction* speed;
        rb.angularVelocity = Random.Range(minAngularRotation, 100f) * (Random.Range(0,100)<50?1f:-1f);
    }

    private void Update()
    {
        if(rb.velocity.magnitude < speed*0.9f)
        {
            direction = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
            rb.velocity = direction * speed;
        }

        if(Mathf.Abs(rb.angularVelocity) < minAngularRotation)
        {
            if(rb.angularVelocity < 0f)
            {
                rb.angularVelocity = -minAngularRotation;
            }else
            {
                rb.angularVelocity = minAngularRotation;

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundController.instance.PlaySound(boingSound,0.6f);
        Vector2 surfaceNormal = collision.contacts[0].normal;
        rb.velocity = Vector2.Reflect(direction * speed, surfaceNormal);
        direction = rb.velocity.normalized;
    }
}
