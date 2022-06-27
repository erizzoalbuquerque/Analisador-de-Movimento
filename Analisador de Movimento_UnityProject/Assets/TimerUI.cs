using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TimerUI : MonoBehaviour
{
    public AnalysisTime timer;
    public TextMeshProUGUI text;

    string label = "Time:";
    string unit = "s";

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = label + " " + timer.TimeSinceLastReset.ToString("F2") + " " + unit;
    }
}
