using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class ChargerMovement : MonoBehaviour
{
    EnemiesStats enemiesStats;
    Rigidbody2D rb;
    PlayerHealthHandler playerHealthHandler;
    GameObject pl;
    EnemyFrozen enemyFrozen;
    public List<AudioClip> audioClipList = new List<AudioClip>();
    

    public Vector2 dir;
    public Vector3 dir3;
    public bool isGoingToCharge = false;
    public bool isCharging = false;
    public float chargingForce = 200;
    private AudioSource au;

    ///CONTADORES

    public float toCharge = 1;
    public float chargeTime= 0.1f;
    public float wait;

    public float waitoffset;
    public float enemyspeedofset;


    public bool muted = false;

    // Start is called before the first frame update
    void Start()
    {

        if (GameManager.instance.currentFloor >= 1)
        {
            GetComponent<EnemiesStats>().enemyHealth *= 1.5f;
        }

        if (GameManager.instance.currentFloor >= 2)
        {
            chargingForce *= 2;
            chargeTime *= 0.7f;

        }

        toCharge = Random.Range(0.5f, 1.5f);
        pl = GameObject.Find("mantee_v2");
        enemiesStats = GetComponent<EnemiesStats>();
        rb = GetComponent<Rigidbody2D>();
        playerHealthHandler = pl.GetComponent<PlayerHealthHandler>();
        enemyFrozen = GetComponent<EnemyFrozen>();
        au = GetComponent<AudioSource>();

        wait = Random.Range(2f, 4.5f);
        var audios = GetComponents<AudioSource>();
        float[] volumnes = new float[audios.Length];
        for (int i = 0; i < audios.Length; i++)
        {
            volumnes[i] = audios[i].volume;
        }

        GetComponent<EnemyDeath>().onHit.AddListener(() => {
            StartCoroutine(HitSoundRoutine());
        });



    }

    float[] volumnes;
    IEnumerator HitSoundRoutine()
    {
        //var audios = GetComponents<AudioSource>();
        //for (int i = 0; i < audios.Length; i++)
        //{
        //    audios[i].enabled = false;
        //}
        yield return new WaitForSeconds(0.5f);

        //for (int i = 0; i < audios.Length; i++)
        //{
        //    audios[i].enabled = true;

        //}
    }

    // Update is called once per frame
    void Update()
    {

        if (playerHealthHandler.isPlayerDead)
        {
            this.enabled = false;
        }
        wait -= Time.deltaTime;
        var audios = GetComponents<AudioSource>();
        if (wait <= 0) {
            
            isGoingToCharge = true;
            toCharge -= Time.deltaTime;

            if (toCharge <= 0.5f && !audios[2].isPlaying)
            {
                audios[0].Stop();
                audios[1].Stop();
                audios[2].Play();
            }

            if (toCharge <= 0)
            {
                isCharging = true;

            }
       }

      
        if (isCharging)
        {

            chargeTime -= Time.deltaTime;

            //audios = GetComponents<AudioSource>();
            

            if(chargeTime <= 0)
            {
                audios[2].Stop();
                audios[1].Play();
                audios[0].Play();
                rb.velocity = Vector2.zero; 
                isCharging = false;
                chargeTime = 1.3f;
                toCharge = Random.Range(0.2f, 1.5f);
                if(GameManager.instance.currentFloor >= 2)
                {
                    chargeTime *= 0.7f;
                    toCharge = Random.Range(0.3f, 1.4f);

                }


            }
        }

        if (!isCharging)
        {
            dir = (pl.transform.position - transform.position).normalized;
        }
        
      
        if (!enemyFrozen.isFrozen)
        {
            if (playerHealthHandler.enemyAttackPaused)
            {
                enemiesStats.enemySpeed = 0;
            }
            else
            {
                enemiesStats.enemySpeed = enemyspeedofset;
            }
        }

   
    }

    private void FixedUpdate()
    {
        if(GameManager.instance.currentFloor >= 2)
        {
            waitoffset = Random.Range(0.6f, 2.5f);

        }
        else
        {
            waitoffset = Random.Range(1f, 3.5f);
        }

        

        if (!isCharging)
        {
            dir3 = (pl.transform.position - transform.position).normalized;
            if (!isGoingToCharge)
            {
                transform.position += dir3.normalized * enemiesStats.enemySpeed * Time.fixedDeltaTime;
            }

        }

        if (isCharging && !enemyFrozen.isFrozen)
        {
            rb.velocity = Vector2.zero;
           
                rb.bodyType = RigidbodyType2D.Dynamic;
                
                rb.AddForce(dir * chargingForce, ForceMode2D.Impulse);
                isGoingToCharge = false;
                wait = waitoffset;
        }
    }
}