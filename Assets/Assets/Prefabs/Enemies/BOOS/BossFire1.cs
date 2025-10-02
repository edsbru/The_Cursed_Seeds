using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire1 : MonoBehaviour
{
    [SerializeField] public int bulletAmount = 10;

    [SerializeField] private float startAngle = 0, endAngle = 360;

    [SerializeField] private int BulletID;

    private Vector2 bulletMoveDirection;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0, 1f);    
    }

    private void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletAmount;
        float angle = startAngle;

        for (int i = 0; i < bulletAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet(BulletID);
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<BossShoot>().SetMoveDirection(bulDir);

            angle += angleStep;        
        }
    }
}