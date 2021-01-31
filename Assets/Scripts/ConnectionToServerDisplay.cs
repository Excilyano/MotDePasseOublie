using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ConnectionToServerDisplay : MonoBehaviour
{
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;
    public TextMeshProUGUI text4;
    public TextMeshProUGUI text5;
    public TextMeshProUGUI text6;
    public TextMeshProUGUI text7;
    public TextMeshProUGUI text8;
    public Button button;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(6.5f);
        text1.enabled = true;

        yield return new WaitForSeconds(3f);
        text2.enabled = true;

        yield return new WaitForSeconds(1f);
        text3.enabled = true;

        yield return new WaitForSeconds(3f);
        text4.enabled = true;

        yield return new WaitForSeconds(1f);
        text5.enabled = true;

        yield return new WaitForSeconds(3f);
        text6.enabled = true;

        yield return new WaitForSeconds(1f);
        text7.enabled = true;

        yield return new WaitForSeconds(1f);
        text8.enabled = true;

        yield return new WaitForSeconds(1f);
        button.interactable = true;
    }
}
