using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] TMP_Text speakerName;
    [SerializeField] TMP_Text speakerDialogue;

    private void Awake()
    {
        DialogueManager.NewDialogueDisplayed.AddListener(OnNewDialogue);
        DialogueManager.DialogueEnded.AddListener(OnDialogueEnd);
    }

    int messageIndex = 0;
    string message;
    float displayTime;
    float displayAlpha;
    void OnNewDialogue()
    {
        mainPanel.SetActive(true);
        messageIndex = 0;
        displayAlpha = 0;
        message = DialogueManager.currentDialog.Message;
        speakerName.text = DialogueManager.currentDialog.Speaker;
        speakerDialogue.text = "";
        displayTime = DialogueManager.currentDialog.DisplayTime / message.Length;
    }

    void OnDialogueEnd()
    {
        mainPanel.SetActive(false);
        
    }

    private void Update()
    {
        if (!DialogueManager.DialogueIsBeingDisplayed) return;

        if (Input.GetMouseButtonDown(0))
        {
            DialogueManager.SkipDialogue();
        }


        displayAlpha += Time.deltaTime;
        displayTime = DialogueManager.currentDialog.DisplayTime / message.Length;
        if (messageIndex != message.Length && displayAlpha >= displayTime)
        {
            displayAlpha = 0;
            speakerDialogue.text = speakerDialogue.text + message[messageIndex];
            messageIndex++;
        }
    }
}
