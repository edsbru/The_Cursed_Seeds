using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class TeacherDialogue : MonoBehaviour
{
    [SerializeField] private GameObject exclamation;
    [SerializeField] private GameObject DialoguePanel;
    [SerializeField] private TMP_Text DialogueText;
    [SerializeField, TextArea(4, 6)] private string[] DialogueLines;
    [SerializeField] private GameObject mantee;
    [SerializeField] private PlayerMovement movement;
    public GameObject Teacher;
    private SpriteRenderer t;
    private BoxCollider2D coll;

    private float typingTime = 0.05f;
    private bool isPlayerInRange;
    private bool didDialogueStart;
    private int lineIndex;
    private bool TpActivate;

    UnityEvent finishDialogEvent = new UnityEvent();

    public void SubscribeToEndDialogEvent(UnityAction callback)
    {
        finishDialogEvent.AddListener(callback);
    }

    private void Start()
    {
        mantee = GameObject.Find("mantee_v2");
        t = Teacher.GetComponent<SpriteRenderer>();
        coll = Teacher.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange && Input.GetButtonDown("interaction"))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (DialogueText.text == DialogueLines[lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                DialogueText.text = DialogueLines[lineIndex];
                GetComponent<AudioSource>().Stop();

            }

        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        DialoguePanel.SetActive(true);
        exclamation.SetActive(false);
        lineIndex = 0;
        movement.enabled = false;
        StartCoroutine(ShowLine());
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().time = 0.2f;
    }

    float lastDialogTime;

    private void NextDialogueLine()
    {
        lineIndex++;
        if (lineIndex < DialogueLines.Length)
        {
            GetComponent<AudioSource>().Play();
            GetComponent<AudioSource>().time = lastDialogTime;
            StartCoroutine(ShowLine());
        }
        else
        {
            try
            {
                GetComponent<SwitchUIIndicator>().enabled = false;

            }catch{

            }
            didDialogueStart = false;
            DialoguePanel.SetActive(false);
            exclamation.SetActive(false);
            exclamation.GetComponent<SpriteRenderer>().enabled = false;
            movement.enabled = true;
            t.enabled = false;
            coll.enabled = false;
            finishDialogEvent.Invoke();
            
        }
    }


    private IEnumerator ShowLine()
    {
        DialogueText.text = string.Empty;

        foreach (char ch in DialogueLines[lineIndex])
        {
            lastDialogTime = GetComponent<AudioSource>().time;
            DialogueText.text += ch;
            yield return new WaitForSecondsRealtime(typingTime);
        }

        lastDialogTime = GetComponent<AudioSource>().time;
        GetComponent<AudioSource>().Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;


        }
    }
}
