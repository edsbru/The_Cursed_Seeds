using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFrozen : MonoBehaviour
{
    public GameObject fixillo;
    public bool isFrozen = false;
    public bool setToFreeze = false;
    private SpriteRenderer sr;
    private float timerHit;
    EnemiesStats enemiesStats;
    public bool isHit = false;
    private float timeToMelt = 0.0f;

    public GameObject ice;
    private SpriteRenderer[] srCubito;
    
    void Start()
    {
        enemiesStats = GetComponent<EnemiesStats>();
        sr = GetComponent<SpriteRenderer>();

        //deshabilitar el spriteRender o el hijo del objeto    
    }

    void Update()
    {
       if (setToFreeze)
       {
           FreezeCharacter();
       }

       if (isFrozen)
       {
       timeToMelt -= Time.deltaTime;

            if (timeToMelt <= 0.0f)
            {

                //MeltCharacter();
            }
       }
    }

    private void FreezeCharacter()
    {
        enemiesStats.enemySpeed = 0;
        ice.SetActive(true);
        isFrozen = true;
        timeToMelt = 5.0f;
        setToFreeze = false;
        
    }

    public void MeltCharacter()
    {
        FindObjectOfType<TutorialOpenRoomTwo>().Bee_1 = Instantiate(fixillo, transform.position, Quaternion.identity);
        Destroy(gameObject);
        return;

        setToFreeze = false;
        ice.SetActive(false);
        enemiesStats.enemySpeed = 2;
        isFrozen = false;
        timeToMelt = 0.0f;
        GetComponent<Animator>().enabled = true;
        var audios = GetComponents<AudioSource>();
        for (int i = 0; i < audios.Length; i++)
        {
            audios[i].enabled = true;
        }

    }
}
