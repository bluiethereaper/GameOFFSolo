using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInteractable : MonoBehaviour, Interactables
{
    public void Interact()
    {
        Destroy(gameObject);
    }
}
