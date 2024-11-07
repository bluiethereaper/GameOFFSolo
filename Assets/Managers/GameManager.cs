using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct Evidence
{
    public string Name;
    public string Desc;
}

public struct Alibi
{
    public string Name;
    public string Desc;
}

public class GameManager : MonoBehaviour
{
    static List<Evidence> _evidenceList = new List<Evidence>();
    static float _gameTime = 0;
    static int _Day = 0;
    public float InvestigationTime = 120;
    public string CriminalName = "Bob";
    static string _criminalName;
    public static UnityEvent<bool> _deactivatePlayer = new UnityEvent<bool>();
    public static UnityEvent<int> _OnNewDay = new UnityEvent<int>();

    private void Awake()
    {
        StartInvestigation(InvestigationTime);
        _criminalName = CriminalName.ToLower();
    }

    private void Update()
    {
        _gameTime -= Time.deltaTime;
    }

    public static void AddEvidence(Evidence evidence)
    {
        _evidenceList.Add(evidence);
    }
    public static Evidence[] GetEvidence()
    {
        return _evidenceList.ToArray();
    }

    public static int GetTimeAsHours()
    {
        return (int)_gameTime / 60;
    }

    public static int GetTimeAsMin()
    {
        return (int)_gameTime % 60;
    }

    public static int GetDay()
    {
        return _Day;
    }

    public static void StartInvestigation(float Length)
    {
        _Day++;
        _OnNewDay.Invoke(_Day);
        _gameTime = Length;
    }

    static bool CheckForCriminal(string suspect)
    {
        suspect = suspect.ToLower();

        return suspect.Equals(_criminalName);
    }

    public static void ArrestSuspect(string suspect)
    {
        if (CheckForCriminal(suspect))
        {
            //if this is the correct suspect the player wins
            print("YOU WIN!");
        }
        else
        {
            print("You Lose");
        }

    }
}
