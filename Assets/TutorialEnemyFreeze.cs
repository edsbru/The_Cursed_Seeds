using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialEnemyFreeze : MonoBehaviour
{
    public GameObject[] room1Enemies;
    Vector2[] room1EnemiesPositions;

    // Start is called before the first frame update
    void Start()
    {

        Debug.Log(gameObject.name);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PlayerMovement>().transform.position.x > 10.04f)
        {
            for (int i = 0; i < room1Enemies.Length; i++)
            {
                room1Enemies[i].gameObject.SetActive(true);
            }
            
            this.enabled = false;
        }

    }
}
