using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbgleScript : MonoBehaviour
{
    public void Explode()
    {
        SoundController.instance.PlaySound(
            CollectSeeds.instace.popSound    
        );
        transform.SetParent(null);
        StartCoroutine(BubbleRoutine());
    }
    IEnumerator BubbleRoutine()
    {
        GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    

}
