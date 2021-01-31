using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnvoiAuServeur32 : MonoBehaviour
{
    public TextMeshProUGUI textSending;

    public Button continueButton;


    string startText;

    void Start()
    {
        startText = textSending.text;
        StartCoroutine(Sequence());
        continueButton.interactable = false;

    }

    IEnumerator Sequence()
    {
        for (int i = 0; i < 24; i++)
        {
            textSending.text = startText + "\n" + new string('.', (i % 3)+1);
            yield return new WaitForSeconds(0.25f);
        }

        yield return new WaitForSeconds(0.5f);

        textSending.text += "\n\nREUSSITE";

        continueButton.interactable = true;
    }
}
