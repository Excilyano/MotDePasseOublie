using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screen29 : MonoBehaviour
{
    public Button continueButton;

    public GameEvent callPlayMusic;

    public GameEvent callStopMusic;

    void Awake()
    {
        continueButton.gameObject.SetActive(false);
    }

    IEnumerator Start()
    {
        callStopMusic.Invoke();

        yield return new WaitForSeconds(70);

        continueButton.gameObject.SetActive(true);
        callPlayMusic.Invoke();
    }
}
