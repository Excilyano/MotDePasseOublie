using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IsWritingText : MonoBehaviour
{
    public TextMeshProUGUI text;

    int counter = 0;


    void Start()
    {
        InvokeRepeating("AddPoint", 0f, 0.25f);
    }

    void AddPoint()
    {
        string content = "A.C.E est en train d'écrire";

        for (int i = 0; i <= counter % 3; i++)
        {
            content += ".";
        }
        
        text.text = content;
        counter++;
    }
}
