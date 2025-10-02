using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteDropeableByTyme : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyRoutine());
    }
    
    bool doingEffect = false;
    IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(3f);
        doingEffect = true;
        yield return new WaitForSeconds(5f);
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        SoundController.instance.PlaySound(
            PlayerMovement.instance.beepSoundEnd
        );
        Destroy(gameObject);
    }

    float beepFrecuency = 0.5f;
    float timeCounter;
    // Update is called once per frame
    void Update()
    {
        if (!doingEffect)
            return;

        timeCounter += Time.deltaTime;

        if(timeCounter > beepFrecuency)
        {
            timeCounter = 0f;
            if(GetComponent<SpriteRenderer>().color == Color.white)
            {
                GetComponent<SpriteRenderer>().color = new Color(1,1,1,0.5f);
                SoundController.instance.PlaySound(
                    PlayerMovement.instance.beepSound,
                    0.7f
                );

            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.white;

            }
            beepFrecuency *= 0.9f;
        }
    }
}
