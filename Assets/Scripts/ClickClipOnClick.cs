using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickClipOnClick : MonoBehaviour
{

    public AudioSource audioSource;

    public AudioClip down;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            audioSource.PlayOneShot(down);
    }
}
