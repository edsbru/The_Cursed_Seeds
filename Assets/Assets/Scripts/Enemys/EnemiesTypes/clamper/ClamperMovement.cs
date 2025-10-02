using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClamperMovement : MonoBehaviour
{
    public Vector3 dir;
    private EnemiesStats enemiesStats;
    public bool isStopped = true;
    public bool isMoving = false;
    public float timerToMove = 2f; 
    public float timerMovement = 1f;
    PlayerHealthHandler playerHealthHandler;
    GameObject pl;

    public GameObject hideOnRun; 

    void Start()
    {
        enemiesStats = GetComponent<EnemiesStats>();
        pl = GameObject.Find("mantee_v2");
        playerHealthHandler = pl.GetComponent<PlayerHealthHandler>();
    }

    bool isShooting;
    
    // Update is called once per frame
    void Update()
    {

        bool nowIsShooting = GetComponent<ClamperShoot>().shooting;
        
        if(isShooting && !nowIsShooting)
        {
            var audios = GetComponents<AudioSource>();
            if (isMoving)
            {
                audios[1].Play();

            }else
            {
                audios[0].Play();

            }
        }
        isShooting = nowIsShooting;


        GetComponent<Animator>().SetBool("shooting", isShooting);

        GetComponent<Animator>().SetBool("moving", isMoving);

        transform.GetChild(transform.childCount-1).GetComponent<SpriteRenderer>().enabled = !(isMoving || isShooting);
        //hideOnRun.SetActive(isMoving);
        if(isMoving || isShooting)
        {
            // set sprite renderer opecity to 0
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);

        }

        if(isShooting)
        {
            var audios = GetComponents<AudioSource>();
            audios[1].Stop();
            audios[0].Stop();
            return;
        }

        if (playerHealthHandler.isPlayerDead)
        {
            this.enabled = false;
        }

        if (isStopped)
        {
            if(Vector2.Distance(transform.position, FindObjectOfType<PlayerMovement>().transform.position) > 6f)
            {
                dir = (FindObjectOfType<PlayerMovement>().transform.position - transform.position).normalized;
                dir.Normalize();

            }else
            {
                dir = new Vector3(UnityEngine.Random.Range(-360, 360), UnityEngine.Random.Range(-360, 360)).normalized;

            }
        }

        if (isStopped)
        {
            timerMovement = 1f;
            timerToMove -= Time.deltaTime;
        }

        if (timerToMove <= 0)
        {
            isStopped = false;
            isMoving = true;

            var audios = GetComponents<AudioSource>();
            audios[0].Stop();
            audios[1].Play();
        }

        if (isMoving)
        {
            timerToMove = UnityEngine.Random.Range(1f,2f);
            timerMovement -= Time.deltaTime;
        }


        if (timerMovement <= 0)
        {
            isStopped = true;
            isMoving = false;
            var audios = GetComponents<AudioSource>();
            audios[1].Stop();
            audios[0].Play();
        }

    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
            transform.position += dir * enemiesStats.enemySpeed * Time.fixedDeltaTime;
        }
    }

}
