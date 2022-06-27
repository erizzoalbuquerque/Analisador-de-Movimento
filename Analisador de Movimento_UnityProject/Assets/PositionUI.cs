using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PositionUI : MonoBehaviour
{
    [SerializeField] TMP_Text text;
    [SerializeField] Transform target;
    [SerializeField] string label = "y pos: ";

    // Start is called before the first frame update
    void Start()
    {
        if (text == null)
            text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = label + target.position.y.ToString("F4");
    }
}
