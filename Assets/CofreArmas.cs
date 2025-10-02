using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreArmas : MonoBehaviour
{

    public GameObject menu;

    public bool playerIn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) {
            if(playerIn)
            {
                GameManager.pendingToPillarArmaNueva = false;
                menu.SetActive(true);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        playerIn = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.GetChild(0).gameObject.SetActive(false);
        playerIn = false;
    }
}
