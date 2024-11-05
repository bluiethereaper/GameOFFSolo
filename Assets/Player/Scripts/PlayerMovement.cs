using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;

public class PlayerMovement : MonoBehaviour
{
    float xInput, yInput;
    [SerializeField] float speed = 10;
    [SerializeField] float CamSpeed = 120;
    [SerializeField] float TurnSpeed = 10;
    [SerializeField] Transform orientation;
    [SerializeField] Transform Body;
    bool playerIsBusy = false;
    Vector3 savedLocation;

    private void Awake()
    {
        DialogueManager.NewDialogueDisplayed.AddListener(OnDialogueStarted);
        DialogueManager.DialogueEnded.AddListener(OnDialogueEnded);
        GameManager.DeactivatePlayer.AddListener(OnPlayerDeactivation);
    }

    void OnDialogueStarted()
    {
        playerIsBusy = true;
    }
    void OnDialogueEnded()
    {
        playerIsBusy = false;
    }
    void OnPlayerDeactivation(bool ActivatePlayer)
    {
        if (ActivatePlayer)
        {
            Body.gameObject.SetActive(false);
            savedLocation = transform.position;
            transform.position = Vector3.down * 100;
            playerIsBusy = true;
        }
        else
        {
            Body.gameObject.SetActive(true);
            transform.position = savedLocation;
            playerIsBusy = false;
        }
    }

    private void Update()
    {
        if (!playerIsBusy)
        {
            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");
            Vector3 dir = (orientation.forward * yInput) + (orientation.right * xInput);
            dir.Normalize();
            dir *= speed;
            //Move player and make them face their move dir
            gameObject.transform.position += dir * Time.deltaTime;
            Body.forward = Vector3.Lerp(Body.forward, dir, TurnSpeed * Time.deltaTime);
            
        }

        //See if there is any Input to mouse
        float mouse = Input.GetAxisRaw("Mouse X");
        orientation.eulerAngles += Vector3.up * mouse * CamSpeed * Time.deltaTime;

    }
}
