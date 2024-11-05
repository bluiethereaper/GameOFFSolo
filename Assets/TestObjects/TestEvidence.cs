using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEvidence : MonoBehaviour, Interactables
{
    public Evidence evidence;
    public void Interact()
    {
        GameManager.AddEvidence(evidence);
        Destroy(gameObject);
    }
}
