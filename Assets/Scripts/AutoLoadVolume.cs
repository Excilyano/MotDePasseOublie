using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AutoLoadVolume : MonoBehaviour
{
    public AudioMixer audioMixer;

    void Start()
    {
        float masterVol = 1f;
        float musicVol = 1f;
        float sfxVol = 1f;

        if (PlayerPrefs.HasKey("MasterVolume"))
            masterVol = PlayerPrefs.GetFloat("MasterVolume");

        if (PlayerPrefs.HasKey("MusicVolume"))
            musicVol = PlayerPrefs.GetFloat("MusicVolume");

        if (PlayerPrefs.HasKey("SFXVolume"))
            sfxVol = PlayerPrefs.GetFloat("SFXVolume");

        SetVolumeLinear("Master", masterVol);
        SetVolumeLinear("Music", musicVol);
        SetVolumeLinear("SFX", sfxVol);
    }

    void SetVolumeLinear(string param, float linearVolume)
    {
        float db = Mathf.Log10(linearVolume) * 20;
        audioMixer.SetFloat(param, db);
    }
}
