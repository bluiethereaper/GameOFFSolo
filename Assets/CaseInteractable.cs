using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CaseInteractable : MonoBehaviour
{
    [SerializeField]BookCase caseParent;
    [SerializeField]UnityEvent action;
    bool wasFound = false;

    private void OnMouseOver()
    {
        if (caseParent.inUse && Input.GetMouseButtonDown(0))
        {
            action.Invoke();
            if (!wasFound)
            {
                GameManager._ShowNotification.Invoke("Secret Found!");
                wasFound = true;
            }
        }
    }
}
