using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelection : MonoBehaviour
{
    private GameObject rotatePoint;
    public static GunSelection instance;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        rotatePoint = GameObject.Find("RotatePoint");
        SelectWeapon(GameManager.instance.currentWeaponID);
    }

    public void SelectWeapon(int weaponIndex)
    {
        GameManager.instance.currentWeaponID = weaponIndex;
        for (int i = 0; i < rotatePoint.transform.childCount; i++)
        {
            rotatePoint.transform.GetChild(i).gameObject.SetActive(weaponIndex == i);
        }
    }
}
