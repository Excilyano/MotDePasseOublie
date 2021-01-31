using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScreenManager : MonoBehaviour
{
    public GameObject reboot;
    public GameObject bluescreen;

    public AudioSource audioSource;
    public AudioClip startup;
    public AudioClip bug;

    void Awake()
    {
        reboot.SetActive(true);
        bluescreen.SetActive(false);
        GetComponent<PressAnyKeyToQuit>().enabled = false;

        StartCoroutine(BlueScreenAppear());
    }

    IEnumerator BlueScreenAppear() {
        audioSource.clip = startup;
        audioSource.Play();

        yield return new WaitForSeconds(7f);
        audioSource.Stop();
        audioSource.clip = bug;
        audioSource.loop = false;
        audioSource.Play();
        yield return new WaitForSeconds(.5f);

        reboot.SetActive(false);
        bluescreen.SetActive(true);

        GetComponent<PressAnyKeyToQuit>().enabled = true;
    }


}
