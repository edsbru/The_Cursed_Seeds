using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyAnim : MonoBehaviour
{
    [SerializeField] private List<Sprite> sprites = new List<Sprite>();
    [SerializeField] private SpriteRenderer rd;
    [SerializeField] private ShootScript shootS;
    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<SpriteRenderer>();
        shootS = GetComponent<ShootScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!shootS.isReloading)
        {


            if (shootS.currentAmmo == 12)
            {
                rd.sprite = sprites[12];
            }
            else if (shootS.currentAmmo == 11)
            {
                rd.sprite = sprites[11];
            }
            else if (shootS.currentAmmo == 10)
            {
                rd.sprite = sprites[10];
            }
            else if (shootS.currentAmmo == 9)
            {
                rd.sprite = sprites[9];
            }
            else if (shootS.currentAmmo == 8)
            {
                rd.sprite = sprites[8];
            }
            else if (shootS.currentAmmo == 7)
            {
                rd.sprite = sprites[7];
            }
            else if (shootS.currentAmmo == 6)
            {
                rd.sprite = sprites[6];
            }
            else if (shootS.currentAmmo == 5)
            {
                rd.sprite = sprites[5];
            }
            else if (shootS.currentAmmo == 4)
            {
                rd.sprite = sprites[4];
            }
            else if (shootS.currentAmmo == 3)
            {
                rd.sprite = sprites[3];
            }
            else if (shootS.currentAmmo == 2)
            {
                rd.sprite = sprites[2];
            }
            else if (shootS.currentAmmo == 1)
            {
                rd.sprite = sprites[1];
            }
            else if (shootS.currentAmmo == 0)
            {
                rd.sprite = sprites[0];
            }
        }

        if (shootS.isReloading)
        {
            shootS.animator.enabled = true;
        }
        else
        {
            shootS.animator.enabled = false;
        }
    }
}
