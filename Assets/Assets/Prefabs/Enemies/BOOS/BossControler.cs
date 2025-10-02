using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControler : MonoBehaviour
{
    [SerializeField] private EnemiesStats bossStats;
    [SerializeField]private List<BossFire1> bossFire1List = new List<BossFire1>();
    [SerializeField]private List<BossFire2> bossFire2List = new List<BossFire2>();
    [SerializeField] private GameObject bee;
    [SerializeField] private List<GameObject> spawnPoint1;
    private float timer = 1f;
    private int spawnBee;
    private float spawnCoolDown = 5f;
    private bool isCoolDOWN = false;
    private float phase2Timer = 2f;
    // Start is called before the first frame update
    void Start()
    {
        bossStats = GetComponent<EnemiesStats>();
    }

    // Update is called once per frame
    void Update()
    {
   
        if(bossStats.enemyHealth > 140)
        {
            bossFire1List[0].bulletAmount = 4; 

        }

        if (bossStats.enemyHealth  < 145 && bossStats.enemyHealth > 120)
        {
            bossFire1List[0].bulletAmount = 6;

        }

        if (bossStats.enemyHealth  < 125 && bossStats.enemyHealth > 110)
        {
            bossFire1List[0].bulletAmount = 10;

        }

        if (bossStats.enemyHealth < 115 && bossStats.enemyHealth > 100)
        {
            bossFire1List[0].bulletAmount = 15;

        }

        if(bossStats.enemyHealth < 95 && bossStats.enemyHealth > 50)
        {
            bossFire1List[0].bulletAmount = -1;
            
            bossFire2List[0].enabled = true;
            
            

            if (!isCoolDOWN)
            {
                Instantiate(bee, spawnPoint1[Random.Range(0,spawnPoint1.Count - 1)].transform.position,Quaternion.identity);
                isCoolDOWN = true;
            }

            if (isCoolDOWN)
            {
                spawnCoolDown -= Time.deltaTime;

                if (spawnCoolDown <= 0)
                {
                    isCoolDOWN = false;
                    spawnCoolDown = 10f;
                }
            }

        }

        if (bossStats.enemyHealth < 40 && bossStats.enemyHealth > 10)
        {
            Destroy(bossFire1List[0]);
            phase2Timer -= Time.deltaTime;

            if (phase2Timer <= 0)
            {
                bossFire2List[1].enabled = true;
                bossFire2List[2].enabled = true;
            }
        }
    }
}
