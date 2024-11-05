using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCTest : MonoBehaviour, Interactables
{
    public Dialogue[] dialogueLines;

    public void Interact()
    {
        foreach (Dialogue line in dialogueLines)
        {
            DialogueManager.AddDialogue(line);
        }
    }

    public void OnEvent()
    {
        print("HIHIHIHI");
    }
}
