using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniterTargeting : MonoBehaviour
{

    public static SniterTargeting instance;
    [SerializeField]
    public AudioClip[] selectionSounds;
    AudioSource selectionSoundsAudioSource;

    public GameObject targetingUI;
    public GameObject targetingFixedUI;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        selectionSoundsAudioSource = GetComponent<AudioSource>();
    }


    private void FixedUpdate()
    {
        transform.rotation = Quaternion.identity;
    }

    public EnemiesStats closest;
    float distanceToClosest;
    void UpdateClosest()
    {
        var enemies = FindObjectsOfType<EnemiesStats>();

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (enemies.Length == 0)
        {
            this.closest = null;
            targeting = false;
            targetingUI.SetActive(false);
            targetingFixedUI.SetActive(false);
            targetFixed = false;
            return;
        }

        EnemiesStats closest = enemies[0];
        float closestDistance = Vector2.Distance(mouseWorldPos, closest.transform.position);

        foreach (var enemy in enemies)
        {
            if (enemy != null && enemy.gameObject.activeSelf)
            {
                float distance = Vector2.Distance(mouseWorldPos, enemy.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closest = enemy;
                }
            }
        }

        this.closest = closest;
        distanceToClosest = closestDistance;
        transform.position = closest.transform.position;
    }

    public bool targetFixed = false;
    public bool targeting;
    float targetingTimeCount = 0;
    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.identity;

        UpdateClosest();


        if(distanceToClosest < 1.5f)
        {
            if (!targeting)
            {
                StartTargeting(closest);
                targeting = true;
                targetingUI.SetActive(true);
                targetingTimeCount = 0f;
            }else
            {
                
                if(!targetFixed)
                {
                    targetingTimeCount += Time.deltaTime;
                    if(targetingTimeCount > 2f)
                    {
                        StartFixedTargeting(closest);
                        targetFixed = true;
                        targetingUI.SetActive(false);
                        targetingFixedUI.SetActive(true);
                    }

                }
            }

        }else
        {
            if (targeting)
            {
                EndTargeting(closest);
            }
            targeting = false;
            targetingUI.SetActive(false);
            targetingFixedUI.SetActive(false);
            targetFixed = false;
        }

        if (!closest)
        {
            targeting = false;
            targetingUI.SetActive(false);
            targetingFixedUI.SetActive(false);
            targetFixed = false;
        }


    }

    float originalHealth = 0f;
    void StartTargeting(EnemiesStats enemy)
    {
        if (!enemy)
        {
            return;
        }
        selectionSoundsAudioSource.PlayOneShot(selectionSounds[2]);

    }
    void StartFixedTargeting(EnemiesStats enemy)
    {

        selectionSoundsAudioSource.PlayOneShot(selectionSounds[0]);

    }

    void EndTargeting(EnemiesStats enemy)
    {
        closest = null;
        selectionSoundsAudioSource.PlayOneShot(selectionSounds[1]);


    }


}
