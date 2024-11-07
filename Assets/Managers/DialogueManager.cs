using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct Dialogue
{
    public string Speaker;
    public string Message;
    public float DisplayTime;
    public UnityEvent action;
}

public class DialogueManager : MonoBehaviour
{
    public static Dialogue currentDialog;
    static List<Dialogue> dialogueQue = new List<Dialogue>();
    public static bool DialogueIsBeingDisplayed = false;
    public static UnityEvent NewDialogueDisplayed = new UnityEvent();
    public static UnityEvent DialogueEnded = new UnityEvent();
    static bool DialogueIsPaused = false;



    public static void SkipDialogue()
    {
        currentDialog.DisplayTime = 0;
    }

    public static void AddDialogue(Dialogue AddedDialogue)
    {
        dialogueQue.Add(AddedDialogue);
    }

    public static void OverrideCurrentDialogue(Dialogue AddedDialogue)
    {
        dialogueQue.Clear();
        currentDialog.DisplayTime = 0;
        dialogueQue.Add(AddedDialogue);
    }

    public static void EndAllDialogue()
    {
        dialogueQue.Clear();
        currentDialog.DisplayTime = 0;
    }


    private void Update()
    {
        //when there is no current dialogue and some is added to que display it
        if (dialogueQue.Count > 0 && !DialogueIsBeingDisplayed)
        {
            currentDialog = dialogueQue[0];
            dialogueQue.RemoveAt(0);
            DialogueIsBeingDisplayed = true;
            NewDialogueDisplayed.Invoke();
            print(currentDialog.Message);
        }
        if (DialogueIsBeingDisplayed && !DialogueIsPaused)
        {
            currentDialog.DisplayTime -= Time.deltaTime;
            if (currentDialog.DisplayTime <= 0)
            {
                currentDialog.action.Invoke();
                DialogueIsBeingDisplayed = false;
                if (dialogueQue.Count <= 0)
                {
                    DialogueEnded.Invoke();
                    print("MESSAGE ENDED");
                }
                    
                
            }
        }
    }
}
