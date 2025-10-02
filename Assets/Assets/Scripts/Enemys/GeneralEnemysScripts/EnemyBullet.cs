using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    private Vector2 dir;
    public BulletStats bulletStats;
    private GameObject player;
    private Transform target;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletStats = GetComponent<BulletStats>();
        player = GameObject.Find("mantee_v2");
        target = player.GetComponent<Transform>();

        var pmove = FindObjectOfType<PlayerMovement>();

        Vector2 playerVelocity = pmove.direction * pmove.playerStats.speed;
        Vector2 playerPosition = pmove.transform.position;

        Vector2 playerWillBeIn = Vector2.zero;

        float distanceToPlayer = Vector2.Distance(playerPosition, transform.position);
        float timeToPlayer = distanceToPlayer / bulletStats.speed;
        playerWillBeIn = playerPosition + playerVelocity * timeToPlayer;

        dir = (playerWillBeIn - (Vector2)transform.position).normalized + (playerPosition - (Vector2)transform.position).normalized;
        rb.velocity = dir.normalized * bulletStats.speed;
    }

}
