using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDialog2 : MonoBehaviour
{
    public GameObject toActivate;
    TeacherDialogue dialog;

    // Start is called before the first frame update
    void Start()
    {
        toActivate.SetActive(false);

        dialog = GetComponent<TeacherDialogue>();
        dialog.SubscribeToEndDialogEvent(() => {
            toActivate.SetActive(true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
