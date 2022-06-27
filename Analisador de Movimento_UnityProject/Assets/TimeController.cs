using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TimeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("ResetAnalysis")]
    public void ResetAnalysis()
    {
        print("ResetAnalysis()");

        AnalysisTime timer = FindObjectOfType<AnalysisTime>();
        timer.Reset();

        Movement movement = FindObjectOfType<Movement>();
        movement.Reset();

        Markers markers = FindObjectOfType<Markers>();
        markers.Reset();
    }

}
