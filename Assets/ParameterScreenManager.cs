using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ParameterScreenManager : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    public AudioMixer audioMixer;

    void Awake()
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

        masterSlider.value = masterVol;
        musicSlider.value = musicVol;
        sfxSlider.value = sfxVol;

        masterSlider.onValueChanged.AddListener(OnMasterChange);
        musicSlider.onValueChanged.AddListener(OnMusicChange);
        sfxSlider.onValueChanged.AddListener(OnSFXChange);
    }

    void OnMasterChange(float newVal)
    {
        SetVolumeLinear("Master", newVal);
        PlayerPrefs.SetFloat("MasterVolume", newVal);
    }

    void OnMusicChange(float newVal)
    {
        SetVolumeLinear("Music", newVal);
        PlayerPrefs.SetFloat("MusicVolume", newVal);
    }

    void OnSFXChange(float newVal)
    {
        SetVolumeLinear("SFX", newVal);
        PlayerPrefs.SetFloat("SFXVolume", newVal);
    }
    
    void SetVolumeLinear(string param, float linearVolume)
    {
        float db = Mathf.Log10(linearVolume) * 20;
        audioMixer.SetFloat(param, db);
    }
}
