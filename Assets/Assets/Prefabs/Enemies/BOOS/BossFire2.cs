using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFire2 : MonoBehaviour
{
    [SerializeField]private float angle = 0f;
    [SerializeField] private float incrementAngle;
    [SerializeField] private int BulletID;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 0.1f);    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Fire()
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

        angle += incrementAngle;

    }
}
