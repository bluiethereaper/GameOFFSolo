using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CaseInteractable : MonoBehaviour
{
    [SerializeField]BookCase caseParent;
    [SerializeField]UnityEvent action;

    private void OnMouseOver()
    {
        if (caseParent.inUse && Input.GetMouseButtonDown(0))
        {
            action.Invoke();
        }
    }
}
