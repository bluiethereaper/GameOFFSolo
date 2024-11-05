using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BookCase : MonoBehaviour, Interactables
{
    [SerializeField] Transform CamHolder;
    public bool inUse { get; private set; } = false;
    [SerializeField] float CameraMovePercent = 0.3f;
    [SerializeField] float moveSpeed = 10;
    [SerializeField] float xMin, xMax, yMin, yMax;
    Vector3 CamLoc;

    //Case Moving Values
    [Header("Bookcase Values")]
    [SerializeField] Transform MoveTransform;
    [SerializeField] float MoveTime = 5;
    Vector3 originalLoc;
    Vector3 moveLoc;
    bool movingCase = false;
    float MoveAlpha = 0;

    private void Awake()
    {
        CamLoc = CamHolder.position;
        originalLoc = transform.position;
        moveLoc = MoveTransform.position;
    }

    private void Update()
    {
        //Move Case when player finds the fake book
        if (movingCase && MoveAlpha < MoveTime)
        {
            MoveAlpha += Time.deltaTime;
            MoveAlpha = Mathf.Clamp(MoveAlpha, 0, MoveTime);
            float currentAlpha = MoveAlpha / MoveTime;
            transform.position = Vector3.Lerp(originalLoc, moveLoc, currentAlpha);
        }
        if (!movingCase && MoveAlpha > 0)
        {
            MoveAlpha -= Time.deltaTime;
            MoveAlpha = Mathf.Clamp(MoveAlpha, 0, MoveTime);
            float currentAlpha = MoveAlpha / MoveTime;
            transform.position = Vector3.Lerp(originalLoc, moveLoc, currentAlpha);
        }


        //Dont Do anything below if were not using it
        if (!inUse) return;


        if (Input.GetKeyDown(KeyCode.Escape))
            Exit();


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
        inUse = true;
        CamHolder.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        GameManager.DeactivatePlayer.Invoke(true);
    }

    public void Exit()
    {
        inUse = false;
        CamHolder.gameObject.SetActive(false);
        GameManager.DeactivatePlayer.Invoke(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    public void MoveCase()
    {
        Exit();
        movingCase = !movingCase;
    }
}
