using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickWeapon : MonoBehaviour
{
    public GameObject weapon;
    public GameObject exclamation;
    public GameObject preWeapon;
    private bool isPlayerInRange;

    public EnemyFrozen enemy;

    // Start is called before the first frame update
    void Start()
    {
        if(preWeapon)
            preWeapon.SetActive(false);    
    }

    bool showingThings = false;
    float timeToShow = 2f;
    bool shown = false;

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("interaction"))
        {
            Destroy(weapon);
            //preWeapon.SetActive(true);
            TutorialGetGunScript.instance.stop = true;
            GameObject.Find("UI").transform.GetChild(0).gameObject.SetActive(true);
            showingThings = true;

            TutorialGetGunScript.instance.DoThen(() =>
            {
                Destroy(exclamation);
                GunSelection.instance.SelectWeapon(0);
                GameObject.Find("RotatePoint").transform.GetChild(0).gameObject.SetActive(true);
                shown = true;
                ShotOnboarding.instance.GetComponent<SpriteRenderer>().enabled = true;
                enemy.MeltCharacter();
                Destroy(GameObject.Find("Teacher_R2"));
            });
        }

    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;


        }
    }
}
