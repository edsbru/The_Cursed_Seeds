using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextFloor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //juego fina: abrir menu donde poder volver al hub o continuar
            if(GameManager.instance.currentFloor == 0)
            {
                GameManager.instance.floor1Passed = true;
            }
            else if (GameManager.instance.currentFloor == 1)
            {
                GameManager.instance.floor2Passed = true;

            }
            else if (GameManager.instance.currentFloor == 2)
            {
                GameManager.instance.floor3Passed = true;

            }

            GameManager.instance.currentFloor++;
            SceneManager.LoadScene("GameplayDefinitivoTest");
        }

    }
}
