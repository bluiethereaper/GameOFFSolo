using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text day;

    private void Update()
    {
        string Hours = GameManager.GetTimeAsHours().ToString();
        string Mins = GameManager.GetTimeAsMin().ToString();
        if (Mins.Length < 2) Mins = "0" + Mins;
        text.text = Hours + ":" + Mins;
        string Day = GameManager.GetDay().ToString();
        day.text = "Day " + Day;
        

    }
}
