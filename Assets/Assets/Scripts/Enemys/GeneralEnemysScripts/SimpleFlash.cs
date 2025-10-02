using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFlash : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    public SpriteRenderer secondSR;

    private SpriteRenderer sp;
    private Material originaMaterial;
    private Material originaMaterials;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        originaMaterial = sp.material;
        if (secondSR)
        {
            originaMaterials = secondSR.material;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void FlashP(float duration)
    {
         IEnumerator FlashRoutine()
        {
                sp.material = flashMaterial;
                
                if (secondSR)
                {
                    secondSR.material = flashMaterial;
                }
                yield return new WaitForSeconds(duration);
                sp.material = originaMaterial;
                if (secondSR)
                {
                    secondSR.material = originaMaterials;
                }

        }
        StartCoroutine(FlashRoutine());
    }

}
