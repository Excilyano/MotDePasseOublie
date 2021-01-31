using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TelephonePageManager : MonoBehaviour
{
    public float delay;
    public TMP_InputField telephoneField;
    public Button button1;
    public Button button2;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        telephoneField.interactable = false;
        yield return new WaitForSeconds(1f);
        button1.interactable = false;
        button2.interactable = false;
        yield return new WaitForSeconds(13f);
        GetComponent<Button>().interactable = true;
    }
}
