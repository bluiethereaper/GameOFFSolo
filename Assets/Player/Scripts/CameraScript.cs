using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform playerLoc;
    [SerializeField] Transform cameraLoc;
    [SerializeField] float maxZoomDistance = 30;
    [SerializeField] float minZoomDistance = 3;
    float currentZoom;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentZoom = -cameraLoc.position.z;
    }

    private void Update()
    {
        //Follow the player
        transform.position = playerLoc.position;
        
        //Look the way the player wants you to
        transform.eulerAngles = playerLoc.eulerAngles;

        //Detect if a wall should be invisible
        Vector3 lookDir = playerLoc.position - cameraLoc.position;
        RaycastHit[] hit =  Physics.RaycastAll(cameraLoc.position,lookDir, currentZoom + 0.1f);
        foreach (RaycastHit rayhit in hit)
        {
            SeeThroughObjects renderer = rayhit.transform.GetComponent<SeeThroughObjects>();
            if (renderer != null)
            {
                renderer.TurnInvisible();
            }
        }


        //HandleZooming
        currentZoom -= Input.mouseScrollDelta.y;
        currentZoom = Mathf.Clamp(currentZoom, minZoomDistance, maxZoomDistance);
        cameraLoc.localPosition = Vector3.forward * -currentZoom;
    }
}
