using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    Interactables currentInteractable;
    public float InteractionRange = 10;
    public Transform sphere;
    public Transform Orient;



    private void Update()
    {
        if (GameManager.isMenuOpen) return;


        //when player presses the interact Button do an interaction
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
            currentInteractable.Interact();

        //Detect Interactables then set the closest one to Current Interactable
        Vector3 pos = Orient.position + Orient.forward;
        RaycastHit[] rays = Physics.SphereCastAll(pos, InteractionRange, Vector3.up, 0);
        float closestRay = InteractionRange;
        bool NoInteractableFound = true;
        foreach (RaycastHit hit in rays)
        {
            Interactables interactable = hit.transform.gameObject.GetComponent<Interactables>();
            if (interactable != null && hit.distance <= closestRay)
            {
                closestRay = hit.distance;
                currentInteractable = interactable;
                NoInteractableFound = false;
            }
        }
        if (NoInteractableFound) currentInteractable = null;

        sphere.localScale = Vector3.one * InteractionRange;
        sphere.position = pos;
    }
}
