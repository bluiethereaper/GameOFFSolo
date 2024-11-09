using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text day;
    public GameObject mainPanel;

    private void Awake()
    {
        GameManager._OpenEvidenceLocker.AddListener(ToggleMainPanel);
    }

    private void Update()
    {
        if (GameManager.isMenuOpen) return;

        string Hours = GameManager.GetTimeAsHours().ToString();
        string Mins = GameManager.GetTimeAsMin().ToString();
        if (Mins.Length < 2) Mins = "0" + Mins;
        text.text = Hours + ":" + Mins;
        string Day = GameManager.GetDay().ToString();
        day.text = "Day " + Day;
    }

    void ToggleMainPanel()
    {
        mainPanel.SetActive(!GameManager.isMenuOpen);
    }
}
