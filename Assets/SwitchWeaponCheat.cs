using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeaponCheat : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GunSelection.instance.SelectWeapon(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            GunSelection.instance.SelectWeapon(1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            GunSelection.instance.SelectWeapon(2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            GunSelection.instance.SelectWeapon(3);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            GunSelection.instance.SelectWeapon(4);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            GunSelection.instance.SelectWeapon(5);
        }


    }

}
