using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowWeaponUI : MonoBehaviour
{
    public static GameObject activeUi;
    public GameObject uiToShow;

    public int idOfGun;
    private GameObject selectedIndicator;

    private void Start()
    {
        selectedIndicator = GameObject.Find("SelectedIndicator");

        if(GameManager.instance.currentWeaponID == idOfGun)
        {
            if (activeUi)
            {
                activeUi.SetActive(false);
            }
            uiToShow.SetActive(true);
            activeUi = uiToShow;
        }
    }

    public void SelectUI() {

        if (activeUi)
        {
            activeUi.SetActive(false);
        }
        uiToShow.SetActive(true);
        activeUi = uiToShow;
        selectedIndicator.transform.position = transform.position;
        GunSelection.instance.SelectWeapon(idOfGun);
    }


}
