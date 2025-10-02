using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class EnemyDeath : MonoBehaviour
{

    EnemiesStats enemiesStats;
    Collider2D cl;
    float timerHit = 0f;
    private SpriteRenderer sr;
    public bool isHit = false;
    private SimpleFlash flash;
    EnemyFrozen enemyFrozen;
    private ParticleSystem blood;
    public GameObject deathSplash;
    public AudioSource hitAudioSource;
    [SerializeField]
    public AudioClip[] hitSounds;
    [SerializeField]
    public AudioClip deathGruntSound;

    [SerializeField]
    public AudioClip[] organicHitSounds;
    [SerializeField]
    public AudioClip organicDeathSound;

    public UnityEvent onHit;

    // Start is called before the first frame update
    void Start()
    {
        blood = GetComponent<ParticleSystem>();

        flash = GetComponent<SimpleFlash>();
        enemiesStats = GetComponent<EnemiesStats>();
        cl = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        enemyFrozen = GetComponent<EnemyFrozen>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesStats.enemyHealth <= 0) {

            for (int i = 0; i < Random.Range(3,10); i++)
            {
              Instantiate(deathSplash, transform.position, Quaternion.identity);
            }
            GetComponent<LootBag>().InstatianteWseed(transform.position);
            Destroy(gameObject);
        }


            if (isHit)
            {
                timerHit -= Time.deltaTime;
                if (timerHit < 0.5f)
                {
                    isHit = false;
                }
            }
  
    }

    bool playingSoundDamage = false;

    IEnumerator BlockDamageSounds()
    {
        playingSoundDamage = true;
        yield return new WaitForSeconds(0.3f);
        playingSoundDamage = false; 
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("bullet"))
        {
            BulletStats bs;
            bs = collision.GetComponent<BulletStats>();
            Destroy(collision.gameObject);
            timerHit = 1;
            flash.FlashP(0.2f);

            isHit = true;

            if(blood)
                blood.Play();

            float damageMultiplier = 1f;
            if(SniterTargeting.instance && SniterTargeting.instance.gameObject.activeSelf && SniterTargeting.instance)
            {
                if (SniterTargeting.instance.targeting)
                {
                    if(SniterTargeting.instance.closest = GetComponent<EnemiesStats>())
                    {
                        if (SniterTargeting.instance.targetFixed)
                        {
                            damageMultiplier = 10f;

                        }
                        else
                        {
                            damageMultiplier = 2f;
                        }
                    }
                }
            }
            Debug.Log(damageMultiplier);
            enemiesStats.enemyHealth -= bs.damage * damageMultiplier;
            if (enemiesStats.enemyHealth <= 0 )
            {
                hitAudioSource.PlayOneShot(deathGruntSound);
                hitAudioSource.transform.SetParent(null);
                SoundController.instance.PlaySound(organicDeathSound, 0.35f);
            }
            else if (!playingSoundDamage)
            {
                StartCoroutine(BlockDamageSounds());
                hitAudioSource.PlayOneShot(
                    hitSounds[Random.Range(0, hitSounds.Length)]
                );
                SoundController.instance.PlaySound(
                    organicHitSounds[Random.Range(0, organicHitSounds.Length)], 0.7f
                );
                onHit.Invoke();

            }
        }
    }


}
