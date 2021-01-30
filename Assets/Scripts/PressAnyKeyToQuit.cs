using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKeyToQuit : MonoBehaviour
{
    bool alreadyQuitting = false;

    // Update is called once per frame
    void Update()
    {
        if (alreadyQuitting)
            return;

        if (Input.anyKeyDown)
        {
            alreadyQuitting = true;
            StartCoroutine(LetsQuit());
        }
    }

    IEnumerator LetsQuit()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
        Debug.Log("It's done for ya !");
    }
}
