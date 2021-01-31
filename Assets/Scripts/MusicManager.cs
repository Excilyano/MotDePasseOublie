using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    public GameEvent callPlayMusic;

    public GameEvent callStopMusic;

    AudioSource audioData;

    void OnEnable()
    {
        callPlayMusic.AddListener(_ => audioData.Play());
        callStopMusic.AddListener(_ => audioData.Stop());
    }

    void Awake()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        audioData.Play();
    }
}
