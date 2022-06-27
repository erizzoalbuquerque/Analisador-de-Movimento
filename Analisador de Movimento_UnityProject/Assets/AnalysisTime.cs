using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalysisTime : MonoBehaviour, IResetable
{   
    public float TimeSinceLastReset { get => timeSinceLastReset;}

    float timeSinceLastReset;
    float lastResetTime;

    void Start()
    {
        Reset();
    }

    void FixedUpdate()
    {
        timeSinceLastReset = Time.time - lastResetTime;
    }

    public void Reset()
    {
        lastResetTime = Time.time;
        timeSinceLastReset = Time.time - lastResetTime;
    }
}
