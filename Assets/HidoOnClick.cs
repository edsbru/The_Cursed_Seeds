using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidoOnClick : MonoBehaviour
{

    public GameObject toHide;
    public void Hide()
    {
        toHide.SetActive(false);
    }
}
