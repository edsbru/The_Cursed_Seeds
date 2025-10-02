using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;
    [SerializeField] private List<GameObject> polledBullet = new List<GameObject>();
    private bool notEnoughtBulletsInPool = true;
    [SerializeField] private GameObject cannon;
    private List<GameObject> bullets;

    private void Awake()
    {
        bulletPoolInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet(int bulletID)
    {
        if (bullets.Count > 0)
        {
            for(int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        if (notEnoughtBulletsInPool)
        {
            GameObject bul = Instantiate(polledBullet[bulletID],cannon.transform.position,Quaternion.identity);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }
        return null;
    }
}
