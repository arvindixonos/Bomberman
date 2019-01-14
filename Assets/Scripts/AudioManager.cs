using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundMap
{
    public eSounds soundType;
    public AudioClip soundClip;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;

    private AudioSource[] audioSources;
    private int numAudioSources = 0;

    public SoundMap[] soundMaps;
    private int numSoundsPresent = 0;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        audioSources = GetComponents<AudioSource>();
        numAudioSources = audioSources.Length;

        numSoundsPresent = soundMaps.Length;
    }

    void OnDestroy()
    {
        Instance = null;
    }

    public AudioSource GetFreeAudioSource()
    {
        for (int i = 0; i < numAudioSources; i++)
        {
            if (!audioSources[i].isPlaying)
                return audioSources[i];
        }

        return null;
    }

    public AudioClip GetSound(eSounds sound)
    {
        for (int i = 0; i < numSoundsPresent; i++)
        {
            if (soundMaps[i].soundType == sound)
                return soundMaps[i].soundClip;
        }

        return null;
    }

    public void PlaySound(eSounds sound)
    {
        AudioSource freeAudioSource = GetFreeAudioSource();

    }
}