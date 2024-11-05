using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public  TMP_Text text;

    private void Update()
    {
        string Hours = GameManager.GetTimeAsHours().ToString();
        string Mins = GameManager.GetTimeAsMin().ToString();
        if (Mins.Length < 2) Mins = "0" + Mins;
        text.text = Hours + ":" + Mins;

    }
}
