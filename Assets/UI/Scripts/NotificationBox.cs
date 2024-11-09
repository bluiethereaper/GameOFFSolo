using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NotificationBox : MonoBehaviour
{
    RectTransform RectTransform;
    [SerializeField] TMP_Text message;

    private void Awake()
    {
        RectTransform = GetComponent<RectTransform>();
        
    }

    [SerializeField] float displayTime = 1;
    [SerializeField] float displayLag = 1;
    float displayAlpha = 0;
    bool displayingMessage = false;
    public void DisplayMessage(string newMessage)
    {
        displayingMessage = true;
        message.text = newMessage;
    }

    private void Update()
    {
        if (displayingMessage)
        {
            displayAlpha += Time.deltaTime;
            float alpha = displayAlpha/displayTime;
            RectTransform.localPosition = Vector3.Lerp(Vector3.right * 500, Vector3.zero, alpha);
            if (displayAlpha >= displayTime + displayLag)
            {
                Destroy(gameObject);
            }
        }
    }

}
