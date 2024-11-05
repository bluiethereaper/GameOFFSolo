using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCase : MonoBehaviour, Interactables
{
    [SerializeField] Transform CamHolder;
    bool inUse = false;
    [SerializeField] float CameraMovePercent = 0.3f;
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float xMin, xMax, yMin, yMax;
    Vector3 CamLoc;

    private void Awake()
    {
        CamLoc = CamHolder.position;
    }

    private void Update()
    {
        Vector3 mouseLoc = Input.mousePosition;
        Vector3 screenSize = new Vector3 (Screen.width, Screen.height);
        Vector3 moveDir = Vector3.zero;
        //Get the move direction based on where the mouse currently is
        if (mouseLoc.y < screenSize.y * CameraMovePercent)
            moveDir -= CamHolder.up;
        if (mouseLoc.y > screenSize.y * (1 - CameraMovePercent))
            moveDir += CamHolder.up;
        if (mouseLoc.x < screenSize.x * CameraMovePercent)
            moveDir -= CamHolder.right;
        if (mouseLoc.x > screenSize.x * (1 - CameraMovePercent))
            moveDir += CamHolder.right;

        Vector3 targetLocation = CamLoc + moveDir.normalized * moveSpeed * Time.deltaTime;
        targetLocation.x = Mathf.Clamp(targetLocation.x, xMin, xMax);
        targetLocation.y = Mathf.Clamp(targetLocation.y, yMin, yMax);
        targetLocation.z = 0;

        CamLoc = targetLocation;
        CamHolder.localPosition = CamLoc;
        
    }

    public void Interact()
    {
        if (inUse) return;
        CamHolder.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
    }

    void Exit()
    {
        CamHolder.gameObject.SetActive(false);
    }
}
