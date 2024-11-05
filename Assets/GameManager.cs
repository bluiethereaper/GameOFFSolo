using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

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
    static List<Evidence> evidenceList = new List<Evidence>();
    static float GameTime = 0;
    public float InvestigationTime = 120;

    private void Awake()
    {
        StartInvestigation(InvestigationTime);
    }

    private void Update()
    {
        GameTime -= Time.deltaTime;
    }

    public static void AddEvidence(Evidence evidence)
    {
        evidenceList.Add(evidence);
    }
    public static Evidence[] GetEvidence()
    {
        return evidenceList.ToArray();
    }

    public static int GetTimeAsHours()
    {
        return (int)GameTime / 60;
    }

    public static int GetTimeAsMin()
    {
        return (int)GameTime % 60;
    }

    public static void StartInvestigation(float Length)
    {
        GameTime = Length;
    }
}
