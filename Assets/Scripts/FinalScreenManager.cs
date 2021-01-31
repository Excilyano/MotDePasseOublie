using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScreenManager : MonoBehaviour
{
    public GameObject reboot;
    public GameObject bluescreen;
    // Start is called before the first frame update
    void Start()
    {
        reboot.SetActive(true);
        bluescreen.SetActive(false);
        GetComponent<PressAnyKeyToQuit>().enabled = false;

        StartCoroutine(BlueScreenAppear());
    }

    IEnumerator BlueScreenAppear() {
        yield return new WaitForSeconds(8f);
        reboot.SetActive(false);
        bluescreen.SetActive(true);

        GetComponent<PressAnyKeyToQuit>().enabled = true;
    }


}
