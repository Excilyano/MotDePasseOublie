using System;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class DateTimeUpdater : MonoBehaviour
{
    TextMeshProUGUI myText;

    void Start() {
        myText = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        DateTime now = DateTime.Now;
        string result = "";
        result += now.Day + "/";
        result += now.Month < 10 ? "0" + now.Month + "/" : now.Month + "/";
        result += now.Year + " - ";
        result += now.Hour + ":";
        result += now.Minute;
        myText.text = result;
    }
}
